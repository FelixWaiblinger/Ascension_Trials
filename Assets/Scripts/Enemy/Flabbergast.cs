using UnityEngine;

public class Flabbergast : Enemy
{    
    protected override void ChargeAttack()
    {
        base.ChargeAttack();
        
        _chargeVisual.GetComponent<LineRenderer>();
    }
}
