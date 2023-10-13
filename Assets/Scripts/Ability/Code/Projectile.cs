using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private float _speed;
    private Vector3 _targetPosition;

    void OnTriggerEnter(Collider other)
    {
        _ability.Activate(transform);
    }

    public void Init(Transform target)
    {
        _targetPosition = target.position;
    }

    void Update()
    {
        if (transform.position == _targetPosition) Destroy(gameObject);

        transform.position = Vector3.MoveTowards(
            transform.position,
            _targetPosition,
            _speed * Time.deltaTime
        );
    }
}
