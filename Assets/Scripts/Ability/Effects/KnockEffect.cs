using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Knock", menuName = "Ability/Effect/Knock")]
[Serializable]
public class KnockEffect : AbilityEffect
{
    public override void Apply(Transform target, Vector3 info)
    {
        target.GetComponent<IKnockable>()?.Knock(info);
    }
}
