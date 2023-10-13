using UnityEngine;

[CreateAssetMenu(fileName = "Explode", menuName = "Ability/Explode")]
public class Explode : Ability
{
    [SerializeField] private GameObject _explosionEffect;

    public override void Activate(Transform caster)
    {
        var players = FindTargets(caster.position, _enemyLayer);

        Instantiate(_explosionEffect, caster.position, caster.rotation);

        ApplyEffects(ref Effects, players);
    }
}
