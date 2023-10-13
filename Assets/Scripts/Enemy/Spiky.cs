using UnityEngine;

public class Spiky : Enemy
{
    protected override void ChargeAttack()
    {
        base.ChargeAttack();

        // _chargeVisual.GetComponent<Material>().color =
        //     new Color(_attackTimer * 10, 50, 50);
    }
}
