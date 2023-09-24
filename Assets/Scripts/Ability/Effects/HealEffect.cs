using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Ability/Effect/Heal")]
[Serializable]
public class HealEffect : AbilityEffect
{
    public override void Apply(Transform target, Vector3 info)
    {
        target.GetComponent<IHealable>()?.Heal(info);
    }
}