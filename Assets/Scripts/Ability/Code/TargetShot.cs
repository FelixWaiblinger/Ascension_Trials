using UnityEngine;

public class TargetedShot : Ability
{
    [SerializeField] private Tranquilize _projectile;

    public override void Activate(Transform caster)
    {
        var target = caster.GetComponent<Enemy>()._target;

        var projectile = Instantiate(
            _projectile,
            caster.position + caster.forward,
            Quaternion.LookRotation(target.position - caster.position)
        );

        ((ITargetable)projectile).Init(target);
    }
}
