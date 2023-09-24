using UnityEngine;

[CreateAssetMenu(fileName = "Tackle", menuName = "Ability/Tackle")]
public class Tackle : Ability
{
    

    public override int Activate(Transform player)
    {
        var origin = player.position + player.forward * Range;
        var targets = FindTargets(origin, LayerMask.NameToLayer("Enemy"));
        
        return 0;
    }
}
