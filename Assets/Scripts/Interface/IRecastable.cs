using UnityEngine;

public interface IRecastable
{
    public int GetCharges();
    public string GetAnimName(int charge);
    public void Activate(Transform origin, int charge);
}
