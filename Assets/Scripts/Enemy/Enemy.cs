using Unity.Netcode;
using UnityEngine;

public abstract class Enemy : NetworkBehaviour, IDamagable, IDoTable, IStunnable, IKnockable
{
    [Header("General")]
    [SerializeField] protected VoidEventChannel _enemyDeathEvent;
    [SerializeField] protected EnemyUI _status;
    protected Rigidbody _rigidBody;
    protected Transform _target;
    protected float _stunTimer;

    [Header("Stats")]
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _armor;
    [SerializeField] protected float _moveSpeed;
    protected float _currentHealth;

    [Header("Ability")]
    [SerializeField] protected Ability _ability;
    [SerializeField] protected float _chargeTime;
    [SerializeField] protected float _attackRange;
    protected bool _isAttacking = false;
    
    protected void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        var players = GameObject.FindGameObjectsWithTag("Player");
        _target = players[Random.Range(0, players.Length)].transform;

        _currentHealth = _maxHealth;
        _status.UpdateHealth(_currentHealth, _maxHealth);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.transform != _target) return;

        _isAttacking = true;
    }

    protected void MoveToTarget()
    {
        if (_stunTimer > 0) return;

        var direction = (_target.position - transform.position).normalized;

        _rigidBody.Move(
            transform.position + direction * _moveSpeed * Time.deltaTime,
            Quaternion.LookRotation(direction)
        );
    }

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

    #endregion
}
