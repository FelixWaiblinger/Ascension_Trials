using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Ability/Dash")]
public class Dash : Ability
{
    public override void Activate(Transform caster)
    {
        ApplyEffects(ref Effects, new Transform[]{caster});
    }
}
