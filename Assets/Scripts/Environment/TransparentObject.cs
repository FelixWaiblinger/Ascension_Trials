using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    [SerializeField] private float _fullyVisibleDistance;
    private MeshRenderer _object;
    private Color _c;
    private Transform _camera;
    
    void Start()
    {
        _object = GetComponent<MeshRenderer>();
        _c = _object.material.color;
        _camera = Camera.main.transform;
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, _camera.position);

        _object.material.color = distance < _fullyVisibleDistance ?
                                 new(_c.r, _c.b, _c.g, distance / _fullyVisibleDistance) :
                                 _c;
    }
}
