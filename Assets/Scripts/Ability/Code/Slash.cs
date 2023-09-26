using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Slash", menuName = "Ability/Slash")]
public class Slash : Ability, IRecastable
{
    public SerializedDictionary<AbilityEffect, Vector3> SecondEffects;
    public SerializedDictionary<AbilityEffect, Vector3> ThirdEffects;
    public List<string> AnimNames;
    public int Charges;
    public int GetCharges() { return Charges; }
    public string GetAnimName(int charge) { return AnimNames[charge]; }

    public void Activate(Transform player, int charge)
    {
        var origin = player.position + player.forward * Range;
        var targets = FindTargets(origin, LayerMask.NameToLayer("Enemy"));

        switch (charge)
        {
            case 0: ApplyEffects(ref Effects, targets); break;
            case 1: ApplyEffects(ref SecondEffects, targets); break;
            case 2: ApplyEffects(ref ThirdEffects, targets); break;
        }
    }

    public override int Activate(Transform player)
    {
        Activate(player, 0);

        return 0;
    }

}
