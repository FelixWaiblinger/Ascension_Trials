using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DoT", menuName = "Ability/Effect/DoT")]
[Serializable]
public class DoTEffect : AbilityEffect
{
    public override void Apply(Transform target, Vector3 info)
    {
        target.GetComponent<IDoTable>()?.DoT(info);
    }
}
