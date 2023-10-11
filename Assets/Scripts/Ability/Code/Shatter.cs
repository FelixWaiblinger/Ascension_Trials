using UnityEngine;

[CreateAssetMenu(fileName = "Shatter", menuName = "Ability/Shatter")]
public class Shatter : Ability
{
    public GameObject VisualEffect;

    public override void Activate(Transform caster)
    {
        var targets = FindTargets(caster.position, LayerMask.NameToLayer("Enemy"));

        Instantiate(VisualEffect, caster.position, Quaternion.identity);

        ApplyEffects(ref Effects, targets);
    }
}
