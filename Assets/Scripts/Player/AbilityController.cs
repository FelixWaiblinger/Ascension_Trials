using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public enum Slot { Attack, Special, Ultimate, Dash, None }

public class AbilityController : NetworkBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private Animator _animator;
    [SerializeField] private FloatEventChannel _moveLockEvent;
    [SerializeField] private Transform _target;
    [SerializeField] private PlayerUI _hud;

    private float _targetOffset = 4;
    private Vector3 _lookDirection;
    private Dictionary<Slot, Ability> _slots = new Dictionary<Slot, Ability>();
    private Dictionary<Slot, float> _cooldownTimers = new Dictionary<Slot, float>()
    {
        { Slot.Attack, 0}, { Slot.Special, 0 }, { Slot.Ultimate, 0 }, { Slot.Dash, 0 }
    };
    private float _castTimer;
    private Slot _castQueue = Slot.None;

    #region SETUP

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }

    void OnEnable()
    {
        InputReader.moveEvent += (direction) => _lookDirection = new(direction.x, 0, direction.y);
        InputReader.attackEvent += () => Cast(Slot.Attack);
        InputReader.specialEvent += () => Cast(Slot.Special);
        InputReader.ultimateEvent += () => Cast(Slot.Ultimate);
        InputReader.dashEvent += () => Cast(Slot.Dash);
    }
    
    void Awake()
    {
        if (_gameData == null) return;

        _slots[Slot.Attack] = _gameData.Attack;
        _slots[Slot.Special] = _gameData.Special;
        _slots[Slot.Ultimate] = _gameData.Ultimate;
    }

    #endregion

    #region UPDATE

    void Update()
    {
        Target();

        Timers();

        if (_castTimer <= 0 && _castQueue != Slot.None) Cast(_castQueue);
    }

    void Target()
    {
        _target.position = transform.position + _lookDirection * _targetOffset;
    }

    void Timers()
    {
        if (_castTimer > 0) _castTimer -= Time.deltaTime;

        foreach (Slot s in _slots.Keys)
        {
            if (_cooldownTimers[s] > 0)
                _cooldownTimers[s] -= Time.deltaTime;

            _hud.UpdateUIElement((UIElement)s, _cooldownTimers[s], _slots[s].Cooldown);
        }
    }

    #endregion

    #region EVENT

    void Cast(Slot s)
    {
        // slot is on cooldown
        if (_cooldownTimers[s] > 0)
        {
            // cannot have slot queued if it is on cooldown
            if (_castQueue == s) _castQueue = Slot.None;
            return;
        }

        // any slot is still being casted
        if (_castTimer > 0 && s != Slot.Dash)
        {
            _castQueue = s;
            return;
        }

        var chargesLeft = _slots[s].Activate(transform);

        _castQueue = Slot.None;
        _castTimer = 0.7f * _animator.GetCurrentAnimatorStateInfo(0).length;
        _moveLockEvent.RaiseFloatEvent(_castTimer);
        _animator.SetTrigger("attack_" + chargesLeft.ToString());

        if (chargesLeft == 0)
        {
            _cooldownTimers[s] = _slots[s].Cooldown;

            _hud.UpdateUIElement((UIElement)s, _cooldownTimers[s], _slots[s].Cooldown);
        }
    }

    #endregion
}
