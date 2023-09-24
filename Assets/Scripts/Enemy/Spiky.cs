using UnityEngine;

public class Spiky : Enemy
{
    [SerializeField] private GameObject _tackleChargeVisual;
    private float _tackleTimer;

    void FixedUpdate()
    {
        if (_isAttacking) return;
        
        MoveToTarget();
    }

    void Update()
    {
        if (!_isAttacking) return;

        ChargeTackle();

        if (_tackleTimer >= _chargeTime) Tackle();
    }

    void ChargeTackle()
    {
        if (!_tackleChargeVisual.activeSelf)
            _tackleChargeVisual.SetActive(true);

        _tackleTimer += Time.deltaTime;
        _tackleChargeVisual.GetComponent<Material>().color = new Color(_tackleTimer * 10, 50, 50);
    }

    void Tackle()
    {
        _ability.Activate(transform);
        _isAttacking = false;
        // _tackleChargeVisual.
        _tackleChargeVisual.SetActive(false);
    }
}
