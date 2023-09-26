using UnityEngine;
using Unity.Netcode;

public class CameraController : NetworkBehaviour
{
    [Header("Options")]
    [SerializeField] private OptionData _options;
    [SerializeField] private VoidEventChannel _optionChangeEvent;

    [Header("Camera movement")]
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _focusPoint;
    [SerializeField] private float _lookAhead;
    [SerializeField] private float _followSmoothness;
    private bool _staticCamera = false;

    #region SETUP

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) this.enabled = false;
    }

    void OnEnable()
    {
        _optionChangeEvent.OnVoidEventRaised += StaticCamera;
    }

    void OnDisable()
    {
        _optionChangeEvent.OnVoidEventRaised -= StaticCamera;
    }

    #endregion
    
    void Update()
    {
        var direction = (_target.position - transform.position).normalized;
        var cameraTarget = transform.position + direction * _lookAhead;

        _focusPoint.position = Vector3.MoveTowards(
            _focusPoint.position,
            cameraTarget,
            _followSmoothness * Time.deltaTime
        );
    }

    void StaticCamera()
    {
        _staticCamera = _options.StaticCamera;
    }
}
