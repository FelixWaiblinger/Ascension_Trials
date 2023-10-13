using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Slash", menuName = "Ability/Slash")]
public class Slash : Ability, IRecastable
{
    public SerializedDictionary<AbilityEffect, Vector3> SecondEffects;
    public SerializedDictionary<AbilityEffect, Vector3> ThirdEffects;
    public List<AnimationClip> Animations;
    public AnimationClip GetAnimation(int charge) { return Animations[charge]; }
    public int Charges;
    public int GetCharges() { return Charges; }
    public float RecastTime;
    public float GetRecastTime() { return RecastTime; }

    public void Activate(Transform caster, int charge)
    {
        var origin = caster.position + caster.forward * Range;
        var targets = FindTargets(origin, _enemyLayer);

        switch (charge)
        {
            case 0: ApplyEffects(ref Effects, targets); break;
            case 1: ApplyEffects(ref SecondEffects, targets); break;
            case 2: ApplyEffects(ref ThirdEffects, targets); break;
        }
    }

    public override void Activate(Transform player)
    {
        Activate(player, 0);
    }

}
