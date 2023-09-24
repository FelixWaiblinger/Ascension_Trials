using UnityEngine;
using Unity.Netcode;

public class CameraController : NetworkBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _focusPoint;
    [SerializeField] private float _lookAhead;
    [SerializeField] private float _followSmoothness;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }
    
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
}
