using UnityEngine;

[CreateAssetMenu(fileName = "Tackle", menuName = "Ability/Tackle")]
public class Tackle : Ability
{
    public override void Activate(Transform caster)
    {
        var origin = caster.position + caster.forward * Range;
        var targets = FindTargets(origin, LayerMask.NameToLayer("Enemy"));
    }
}
