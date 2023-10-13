using Unity.Netcode;
using UnityEngine;

public abstract class Enemy : NetworkBehaviour, IDamagable, IDoTable, IStunnable, IKnockable, ISlowable
{
    [Header("General")]
    [SerializeField] protected VoidEventChannel _enemyDeathEvent;
    [SerializeField] protected EnemyUI _status;
    protected Rigidbody _rigidBody;
    public Transform _target { get; protected set; }

    [Header("Stats")]
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _armor;
    [SerializeField] protected float _moveSpeed;
    protected float _currentHealth;
    protected float _stunTimer, _slowFactor = 1, _slowTimer;

    [Header("Ability")]
    [SerializeField] protected Ability _ability;
    [SerializeField] protected GameObject _chargeVisual;
    [SerializeField] protected float _chargeTime;
    protected bool _isAttacking = false;
    protected float _attackTimer;
    
    #region SETUP

    protected void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        var players = GameObject.FindGameObjectsWithTag("Player");
        _target = players[Random.Range(0, players.Length)].transform;

        var look = _target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(look);

        _currentHealth = _maxHealth;
        _status.UpdateHealth(_currentHealth, _maxHealth);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.transform != _target) return;

        if (_isAttacking) return;

        _isAttacking = true;
        _attackTimer = _chargeTime;
        _chargeVisual.SetActive(true);
    }

    #endregion

    void Update()
    {
        UpdateTimers();

        if (!_isAttacking) Move();
        else if (_attackTimer > 0) ChargeAttack();
        else Attack();
    }

    void UpdateTimers()
    {
        var time = Time.deltaTime;

        if (_stunTimer > 0) _stunTimer -= time;

        if (_slowTimer > 0)
        {
            _slowTimer -= time;
            if (_slowTimer < 0) _slowFactor = 1;
        }
    }

    protected void Move()
    {
        if (_stunTimer > 0) return;

        var direction = (_target.position - transform.position).normalized;

        _rigidBody.Move(
            transform.position + direction * _moveSpeed * _slowFactor * Time.deltaTime,
            Quaternion.LookRotation(direction)
        );
    }

    #region ATTACK

    protected virtual void ChargeAttack()
    {
        _attackTimer -= Time.deltaTime;
    }

    protected virtual void Attack()
    {
        _ability.Activate(transform);
        _isAttacking = false;
        _chargeVisual.SetActive(false);
    }

    #endregion

    #region INTERFACE

    public void Damage(Vector3 info)
    {
        _currentHealth -= Mathf.Clamp(info.x - _armor, 0, info.x);
        _status.UpdateHealth(_currentHealth, _maxHealth);
    }

    public void DoT(Vector3 info)
    {

    }

    public void Stun(Vector3 info)
    {
        _stunTimer = info.x;
    }

    public void Knock(Vector3 info)
    {
        var force = new Vector3(info.x, 0, info.y) * info.z;
        _rigidBody.AddForce(force, ForceMode.Acceleration);
    }

    public void Slow(Vector3 info)
    {
        _slowFactor = info.x;
        _slowTimer = info.y;
    }

    #endregion
}
