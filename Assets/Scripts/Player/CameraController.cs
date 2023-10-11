using UnityEngine;
using Unity.Netcode;

public class CameraController : NetworkBehaviour
{
    [Header("Camera movement")]
    [SerializeField] private Transform _focusPoint;
    [SerializeField] private float _lookAhead;
    [SerializeField] private float _followSmoothness;
    private Vector3 _lookDirection;
    private bool _staticCamera = false;

    [Header("Options")]
    [SerializeField] private OptionData _options;
    [SerializeField] private VoidEventChannel _optionChangeEvent;

    #region SETUP

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) this.enabled = false;
    }

    void OnEnable()
    {
        InputReader.moveEvent += Look;
        _optionChangeEvent.OnVoidEventRaised += StaticCamera;
    }

    void OnDisable()
    {
        InputReader.moveEvent -= Look;
        _optionChangeEvent.OnVoidEventRaised -= StaticCamera;
    }

    #endregion
    
    void Update()
    {
        var speed = _followSmoothness * _lookDirection == Vector3.zero ? 2 : 1;
        _focusPoint.position = Vector3.MoveTowards(
            _focusPoint.position,
            transform.position + _lookDirection,
            speed * Time.deltaTime
        );
    }

    void Look(Vector2 direction)
    {
        _lookDirection = new Vector3(direction.x, 0, direction.y) * _lookAhead;
    }

    void StaticCamera()
    {
        _staticCamera = _options.StaticCamera;
    }
}
