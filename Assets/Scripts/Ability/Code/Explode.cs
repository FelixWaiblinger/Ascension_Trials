using UnityEngine;

[CreateAssetMenu(fileName = "Explode", menuName = "Ability/Explode")]
public class Explode : Ability
{
    [SerializeField] private GameObject _explosionEffect;

    public override int Activate(Transform origin)
    {
        var players = FindTargets(
            origin.position,
            origin.gameObject.layer == LayerMask.NameToLayer("Player") ?
                LayerMask.NameToLayer("Enemy") : LayerMask.NameToLayer("Player")
        );

        Instantiate(_explosionEffect, origin.position, origin.rotation);

        ApplyEffects(ref Effects, players);
        
        return 0;
    }
}
