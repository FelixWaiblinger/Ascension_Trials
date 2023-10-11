using UnityEngine;

[CreateAssetMenu(fileName = "Explode", menuName = "Ability/Explode")]
public class Explode : Ability
{
    [SerializeField] private GameObject _explosionEffect;

    public override void Activate(Transform caster)
    {
        var players = FindTargets(
            caster.position,
            caster.gameObject.layer == LayerMask.NameToLayer("Player") ?
                LayerMask.NameToLayer("Enemy") : LayerMask.NameToLayer("Player")
        );

        Instantiate(_explosionEffect, caster.position, caster.rotation);

        ApplyEffects(ref Effects, players);
    }
}
