using UnityEngine;

public class Blobber : Enemy
{
    protected override void ChargeAttack()
    {
        base.ChargeAttack();

        _chargeVisual.transform.localScale =
            Vector3.one * Mathf.Clamp(_attackTimer * 3, 0, _ability.Range);
    }

    protected override void Attack()
    {
        base.Attack();
        
        Destroy(gameObject);
    }
}
