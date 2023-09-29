using UnityEngine;

public interface IRecastable
{
    public int GetCharges();
    public float GetRecastTime();
    public AnimationClip GetAnimation(int charge);
    public void Activate(Transform origin, int charge);
}
