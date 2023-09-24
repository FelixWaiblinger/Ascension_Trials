using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Slash", menuName = "Ability/Slash")]
public class Slash : Ability
{
    public SerializedDictionary<AbilityEffect, Vector3> SecondEffects;
    public SerializedDictionary<AbilityEffect, Vector3> ThirdEffects;
    public int Charges;

    private int _currentCharge = 0;

    public override int Activate(Transform player)
    {
        var origin = player.position + player.forward * Range;
        var targets = FindTargets(origin, LayerMask.NameToLayer("Enemy"));
        
        switch (_currentCharge)
        {
            case 0: ApplyEffects(ref Effects, targets); break;
            case 1: ApplyEffects(ref SecondEffects, targets); break;
            case 2: ApplyEffects(ref ThirdEffects, targets); break;
        }

        _currentCharge++;
        var chargesLeft = Charges - _currentCharge;
        if (chargesLeft <= 0) _currentCharge = 0;

        return chargesLeft;
    }
}
