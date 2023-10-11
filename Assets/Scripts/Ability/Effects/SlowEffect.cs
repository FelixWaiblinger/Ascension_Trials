using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Slow", menuName = "Ability/Effect/Slow")]
[Serializable]
public class SlowEffect : AbilityEffect
{
    public override void Apply(Transform target, Vector3 info)
    {
        target.GetComponent<ISlowable>()?.Slow(info);
    }
}
