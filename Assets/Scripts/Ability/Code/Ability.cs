using System.Linq;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public abstract class Ability : ScriptableObject
{
    public Sprite Icon;
    public float CastTime;
    public float ActiveTime;
    public float CooldownTime;
    public float Range;
    public string AnimName;
    public SerializedDictionary<AbilityEffect, Vector3> Effects;

    // returns the amount of charges left
    public abstract int Activate(Transform origin);

    protected void ApplyEffects(ref SerializedDictionary<AbilityEffect, Vector3> effects, Transform[] targets)
    {
        foreach ((AbilityEffect effect, Vector3 info) in effects)
        {
            foreach (Transform target in targets) effect.Apply(target, info);
        }
    }

    protected Transform[] FindTargets(Vector3 origin, LayerMask layers)
    {
        var targets = Physics.OverlapSphere(origin, Range, layers, QueryTriggerInteraction.Ignore);

        return targets.Select(collider => collider.transform).ToArray();
    }
}
