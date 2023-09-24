using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Ability/Effect/Damage")]
[Serializable]
public class DamageEffect : AbilityEffect
{
    public override void Apply(Transform target, Vector3 info)
    {
        target.GetComponent<IDamagable>()?.Damage(info);
    }
}
