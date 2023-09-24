using UnityEngine;

public class Flabbergast : Enemy
{
    [SerializeField] private GameObject _shootChargeVisual;
    private float _shootTimer;
    
    void FixedUpdate()
    {
        if (_isAttacking) return;
        
        MoveToTarget();
    }

    void Update()
    {
        if (!_isAttacking) return;

        ChargeShoot();

        if (_shootTimer >= _chargeTime) Shoot();
    }

    void ChargeShoot()
    {
        if (!_shootChargeVisual.activeSelf)
            _shootChargeVisual.SetActive(true);

        _shootTimer += Time.deltaTime;
        _shootChargeVisual.GetComponent<LineRenderer>();
    }

    void Shoot()
    {
        _ability.Activate(transform);
        _isAttacking = false;
        // _shootChargeVisual.
        _shootChargeVisual.SetActive(false);
    }
}
