using UnityEngine;

[CreateAssetMenu(fileName = "Shatter", menuName = "Ability/Shatter")]
public class Shatter : Ability
{
    public GameObject VisualEffect;

    public override int Activate(Transform player)
    {
        var targets = FindTargets(player.position, LayerMask.NameToLayer("Enemy"));

        Instantiate(VisualEffect, player.position, player.rotation);

        ApplyEffects(ref Effects, targets);

        return 0;
    }
}
