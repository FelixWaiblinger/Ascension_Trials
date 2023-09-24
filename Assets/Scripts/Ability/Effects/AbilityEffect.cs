using System;
using UnityEngine;

[Serializable]
public class AbilityEffect : ScriptableObject
{
    public virtual void Apply(Transform target, Vector3 info) {}
}
