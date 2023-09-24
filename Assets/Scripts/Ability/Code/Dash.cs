using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Ability/Dash")]
public class Dash : Ability
{
    public override int Activate(Transform origin)
    {
        var player = new Transform[]{origin};
        ApplyEffects(ref Effects, player);

        return 0;
    }
}
