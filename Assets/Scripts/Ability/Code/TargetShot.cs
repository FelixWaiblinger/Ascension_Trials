using UnityEngine;

[CreateAssetMenu(fileName = "TargetShot", menuName = "Ability/TargetShot")]
public class TargetShot : Ability
{
    [SerializeField] private Projectile _projectile;

    public override void Activate(Transform caster)
    {
        var target = caster.GetComponent<Enemy>()._target;

        var projectile = Instantiate(
            _projectile,
            caster.position,
            Quaternion.LookRotation(target.position - caster.position)
        );

        projectile.Init(target);
    }
}
