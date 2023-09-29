using UnityEngine;
using Unity.Netcode;

public class MovementController : NetworkBehaviour, IDashable, IKnockable
{
    [SerializeField] private FloatEventChannel _moveLockEvent;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private AnimationCurve _accelerationCurve;
    private Rigidbody _rigidBody;
    private Transform _visuals;
    private Animator _animator;
    private Vector3 _moveDirection, _lookDirection;
    private float _accelerationTime = 0, _lockTimer = 0;

    [Header("Dash")]
    [SerializeField] private float _dashSpeed;
    private CapsuleCollider _collider;
    private float _dashDurationTimer = 0;

    #region SETUP

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) this.enabled = false;
    }

    void OnEnable()
    {
        InputReader.moveEvent += (direction) => _moveDirection = new(direction.x, 0, direction.y);
        _moveLockEvent.OnFloatEventRaised += Lock;
    }

    void OnDisable()
    {
        _moveLockEvent.OnFloatEventRaised -= Lock;
    }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _animator = GetComponentInChildren<Animator>();
        _visuals = _animator.transform;
    }

    public void Init(float speed)
    {
        _moveSpeed = speed;
    }

    #endregion

    #region MOVEMENT

    void FixedUpdate()
    {
        if (_lockTimer > 0) return;

        Move();

        Rotate();
    }

    void Lock(float duration)
    {
        _lockTimer = duration;
    }

    void Move()
    {
        var acceleration = _accelerationCurve.Evaluate(_accelerationTime);

        if (_moveDirection == Vector3.zero)
            _accelerationTime = 0;
        else
        {
            _accelerationTime += Time.deltaTime;
            var speed = _dashDurationTimer > 0 ? _dashSpeed : _moveSpeed * acceleration;

            _rigidBody.Move(
                _rigidBody.position + _moveDirection.normalized * speed * Time.deltaTime,
                Quaternion.identity
            );
        }

        Animate(acceleration);
    }

    void Rotate()
    {
        if (_moveDirection == Vector3.zero) return;

        _visuals.rotation = Quaternion.RotateTowards(
            _visuals.rotation,
            Quaternion.LookRotation(_moveDirection),
            _turnSpeed
        );
    }

    void Animate(float acceleration)
    {
        var yaw = _visuals.rotation.eulerAngles.y;
        var direction = _visuals.rotation * _moveDirection * acceleration;

        // looking   RIGHT                        LEFT
        if ((yaw > 45 && yaw < 135) || (yaw >= 225 && yaw <= 315))
        {
            direction *= -1;
        }

        _animator.SetFloat("velocityX", direction.x);
        _animator.SetFloat("velocityZ", direction.z);
    }

    #endregion

    #region INTERFACE

    public void Dash(Vector3 info)
    {
        Debug.Log("Setting dash timer");
        _dashDurationTimer = info.x;
        _collider.enabled = info.y > 0;
    }

    public void Knock(Vector3 info)
    {
        _rigidBody.AddForce(
            new Vector3(info.x, 0, info.y) * info.z,
            ForceMode.Acceleration
        );
    }

    #endregion

    void Update()
    {
        var decrement = Time.deltaTime;

        if (_lockTimer > 0) _lockTimer -= decrement;

        if (_dashDurationTimer > 0)
        {
            _dashDurationTimer -= decrement;

            if (_dashDurationTimer < 0) _collider.enabled = true;
        }
        
    }
}
