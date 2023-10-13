using UnityEngine;

public class Flabbergast : Enemy
{
    [SerializeField] private ParticleSystem _chargeEffect;
    [SerializeField] private ParticleSystem _shotEffect;
    private bool _charging = false;

    protected override void ChargeAttack()
    {
        if (!_charging)
        {
            _chargeEffect.Play();
            _charging = true;
        }

        base.ChargeAttack();
        
        var line = new Vector3[]
        {
            transform.position + Vector3.up * 1.5f,
            _target.position + Vector3.up
        };
        _chargeVisual.GetComponent<LineRenderer>().SetPositions(line);
    }

    protected override void Attack()
    {
        base.Attack();

        _chargeVisual.SetActive(false);
        _chargeEffect.Stop();
        _shotEffect.Play();
        _charging = false;
    }
}
