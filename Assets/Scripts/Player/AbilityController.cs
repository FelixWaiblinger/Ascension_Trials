using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public enum Slot { Attack, Special, Ultimate, Dash, None }

public class AbilityController : NetworkBehaviour
{
    [SerializeField] private FloatEventChannel _moveLockEvent;
    [SerializeField] private PlayerUI _hud;
    private Animator _animator;
    private Vector3 _targetDirection;
    private Dictionary<Slot, Ability> _slots = new Dictionary<Slot, Ability>();
    private Dictionary<Slot, float> _activeTimers = new Dictionary<Slot, float>()
    {
        { Slot.Attack, 0}, { Slot.Special, 0 }, { Slot.Ultimate, 0 }, { Slot.Dash, 0 }
    };
    private Dictionary<Slot, float> _cooldownTimers = new Dictionary<Slot, float>()
    {
        { Slot.Attack, 0}, { Slot.Special, 0 }, { Slot.Ultimate, 0 }, { Slot.Dash, 0 }
    };
    private Dictionary<Slot, int> _chargeCounters = new Dictionary<Slot, int>()
    {
        { Slot.Attack, 0}, { Slot.Special, 0 }, { Slot.Ultimate, 0 }, { Slot.Dash, 0 }
    };
    private Slot _castCurrent = Slot.None;
    private Slot _castQueue = Slot.None;
    private float _castLockTimer;

    #region SETUP

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) this.enabled = false;
    }

    void OnEnable()
    {
        InputReader.moveEvent += (direction) => _targetDirection = new(direction.x, 0, direction.y);
        InputReader.attackEvent += () => Cast(Slot.Attack);
        InputReader.specialEvent += () => Cast(Slot.Special);
        InputReader.ultimateEvent += () => Cast(Slot.Ultimate);
        InputReader.dashEvent += () => Cast(Slot.Dash);
    }

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        foreach ((var slot, var ability) in _slots)
        {
            if (ability is not IRecastable) continue;
            
            _chargeCounters[slot] = (ability as IRecastable).GetCharges();
        }
    }
    
    public void Init(Dictionary<Slot, Ability> abilities)
    {
        _slots = abilities;
    }

    #endregion

    #region UPDATE

    void Update()
    {
        Casting();

        ActiveAbilities();

        Timers();
    }

    void Casting()
    {
        if (_castCurrent == Slot.None) return;

        if (_castLockTimer > 0) return;

        _activeTimers[_castCurrent] = _slots[_castCurrent].ActiveTime;
        _castCurrent = Slot.None;
    }

    void ActiveAbilities()
    {
        foreach (Slot s in _slots.Keys)
        {
            if (_activeTimers[s] > 0) continue;

            _cooldownTimers[s] = _slots[s].CooldownTime;
        }
    }

    void Timers()
    {
        if (_castLockTimer <= 0 && _castQueue != Slot.None) Cast(_castQueue);

        var time = Time.deltaTime;

        if (_castLockTimer > 0) _castLockTimer -= time;

        foreach (Slot s in _slots.Keys)
        {
            if (_activeTimers[s] > 0) _activeTimers[s] -= time;

            if (_cooldownTimers[s] > 0)
            {
                _cooldownTimers[s] -= time;
                _hud.UpdateUIElement((UIElement)s, _cooldownTimers[s], _slots[s].CooldownTime);
            }
        }
    }

    #endregion

    void Cast(Slot s)
    {
        // do not cast as slot is on cooldown
        if (_cooldownTimers[s] > 0)
        {
            // cannot have slot queued if it is on cooldown
            if (_castQueue == s) _castQueue = Slot.None;
            return;
        }

        // put slot in queue as another slot is still being casted
        if (_castLockTimer > 0 && s != Slot.Dash)
        {
            _castQueue = s;
            return;
        }

        // start actual casting
        _castCurrent = s;
        _castQueue = Slot.None;
        _castLockTimer = _slots[s].CastTime;
        _moveLockEvent.RaiseFloatEvent(_castLockTimer);

        // single-use abilites
        if (_slots[s] is not IRecastable)
        {
            _slots[s].Activate(transform);
            _animator.SetTrigger(_slots[s].AnimName);
        }
        // recastable abilites
        else
        {
            var slot = (_slots[s] as IRecastable);
            slot.Activate(transform, _chargeCounters[s]++);
            _animator.SetTrigger(slot.GetAnimName(_chargeCounters[s]));
            
            if (_chargeCounters[s] >= slot.GetCharges())
            {
                _castCurrent = Slot.None;
                _cooldownTimers[s] = _slots[s].CooldownTime;
                _chargeCounters[s] = 0;
            }
        }
    }
}
