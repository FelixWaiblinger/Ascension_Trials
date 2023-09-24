using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stun", menuName = "Ability/Effect/Stun")]
[Serializable]
public class StunEffect : AbilityEffect
{
    public override void Apply(Transform target, Vector3 info)
    {
        target.GetComponent<IStunnable>()?.Stun(info);
    }
}
