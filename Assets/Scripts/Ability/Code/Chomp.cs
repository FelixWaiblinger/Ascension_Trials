using UnityEngine;

public class Chomp : Ability
{
    public override void Activate(Transform caster)
    {
        var origin = caster.position + caster.forward * Range;
        var targets = FindTargets(origin, _playerLayer);

        ApplyEffects(ref Effects, targets);
    }
}
