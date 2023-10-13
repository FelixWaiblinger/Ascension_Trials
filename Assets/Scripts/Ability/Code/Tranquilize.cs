using UnityEngine;

public class Tranquilize : Ability, ITargetable
{
    private Transform _target;

    public override void Activate(Transform caster)
    {
        
    }

    public void Init(Transform target)
    {
        _target = target;
    }
}
