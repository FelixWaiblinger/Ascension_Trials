using UnityEngine;

public class Blobber : Enemy
{
    [Header("Blobber")]
    [SerializeField] private GameObject _explosionRadiusVisual;
    private float _explosionTimer;

    void FixedUpdate()
    {
        if (_isAttacking) return;
        
        MoveToTarget();
    }

    void Update()
    {
        if (!_isAttacking) return;

        ChargeExplosion();

        if (_explosionTimer >= _chargeTime) Explode();
    }

    void ChargeExplosion()
    {
        if (!_explosionRadiusVisual.activeSelf)
            _explosionRadiusVisual.SetActive(true);

        _explosionTimer += Time.deltaTime;
        var size = Mathf.Clamp(_explosionTimer * 3, 0, _ability.Range);
        _explosionRadiusVisual.transform.localScale = Vector3.one * size;
    }

    void Explode()
    {
        _ability.Activate(transform);

        Destroy(gameObject);
    }
}
