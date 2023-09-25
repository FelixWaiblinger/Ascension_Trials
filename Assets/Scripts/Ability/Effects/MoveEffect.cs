using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Ability/Effect/Move")]
[Serializable]
public class MoveEffect : AbilityEffect
{
    public override void Apply(Transform target, Vector3 info)
    {
        target.GetComponent<IDashable>()?.Dash(info);
    }
}
