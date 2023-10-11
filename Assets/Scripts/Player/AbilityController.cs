using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public enum Slot
{
    Attack, Special, Ultimate, Dash, None
}

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
    private Dictionary<Slot, float> _recastTimers = new Dictionary<Slot, float>()
    {
        { Slot.Attack, 0}, { Slot.Special, 0 }, { Slot.Ultimate, 0 }, { Slot.Dash, 0 }
    };
    private Dictionary<Slot, int> _chargeCounters = new Dictionary<Slot, int>()
    {
        { Slot.Attack, 0}, { Slot.Special, 0 }, { Slot.Ultimate, 0 }, { Slot.Dash, 0 }
    };
    private Slot _castCurrent = Slot.None;
    private Slot _castQueue = Slot.None;
    private float _castLockTimer = 0;

    #region SETUP

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) this.enabled = false;
    }

    void Start()
    {
        InputReader.moveEvent += (direction) => _targetDirection = new(direction.x, 0, direction.y);
        InputReader.attackEvent += () => Cast(Slot.Attack);
        InputReader.specialEvent += () => Cast(Slot.Special);
        InputReader.ultimateEvent += () => Cast(Slot.Ultimate);
        InputReader.dashEvent += () => Cast(Slot.Dash);

        _animator = GetComponentInChildren<Animator>();

        foreach (var slot in _slots.Keys)
            _hud.UpdateUIElement(
                (UIElement)slot,
                _cooldownTimers[slot],
                _slots[slot].CooldownTime
            );
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

        Actives();

        Cooldowns();
    }

    void Casting()
    {
        if (_castCurrent == Slot.None) return;

        if (_castLockTimer > 0)
        {
            _castLockTimer -= Time.deltaTime;
            if (_castLockTimer > 0) return;

            _activeTimers[_castCurrent] = _slots[_castCurrent].ActiveTime;
            
            if (_slots[_castCurrent] is not IRecastable)
                _slots[_castCurrent].Activate(transform);
            else
            {
                var recastable = _slots[_castCurrent] as IRecastable;
                recastable.Activate(transform, _chargeCounters[_castCurrent]);
                _recastTimers[_castCurrent] = recastable.GetRecastTime();
                _chargeCounters[_castCurrent]++;
            }
            
            _castCurrent = Slot.None;
        }
        else if (_castQueue != Slot.None) Cast(_castQueue);
    }

    void Actives()
    {
        foreach (Slot s in _slots.Keys)
        {
            // recasting abilities
            if (_recastTimers[s] > 0)
            {
                _recastTimers[s] -= Time.deltaTime;

                if (_recastTimers[s] > 0) continue;
                
                _cooldownTimers[s] = _slots[s].CooldownTime;
                _chargeCounters[s] = 0;
            }

            // active ability effects
            if (_activeTimers[s] > 0)
            {
                _activeTimers[s] -= Time.deltaTime;

                if (_activeTimers[s] > 0) continue;
                
                _cooldownTimers[s] = _slots[s].CooldownTime;
                if (_slots[s] is IRecastable) _chargeCounters[s] = 0;
            }
        }
    }

    void Cooldowns()
    {
        foreach (Slot s in _slots.Keys)
        {
            if (_cooldownTimers[s] > 0)
            {
                _cooldownTimers[s] = Mathf.Max(0, _cooldownTimers[s] - Time.deltaTime);
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

        var recastable = (_slots[s] as IRecastable);

        // recastable abilites
        if (recastable != null)
        {
            // atleast one charge left
            if (_chargeCounters[s] < recastable.GetCharges())
                _animator.Play(recastable.GetAnimation(_chargeCounters[s]).name, 0);
            // no more charges left
            else
            {
                _recastTimers[s] = 0;
                return;
            }
        }
        // single-use abilites
        else _animator.Play(_slots[s].Animation.name, 0);

        // start actual casting
        _castCurrent = s;
        _castQueue = Slot.None;
        _castLockTimer = _slots[s].CastTime;
        _moveLockEvent.RaiseFloatEvent(_castLockTimer);
    }
}
