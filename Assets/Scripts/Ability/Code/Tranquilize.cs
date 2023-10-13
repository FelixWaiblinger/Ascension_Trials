using UnityEngine;

[CreateAssetMenu(fileName = "Tranquilize", menuName = "Ability/Tranquilize")]
public class Tranquilize : Ability, ITargetable
{
    private Transform _target;

    public override void Activate(Transform caster)
    {
        var players = FindTargets(caster.position, _playerLayer);

        ApplyEffects(ref Effects, players);
    }

    public void Init(Transform target)
    {
        _target = target;
    }
}
