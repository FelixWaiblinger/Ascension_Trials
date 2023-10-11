using UnityEngine;

[CreateAssetMenu(fileName = "Bladestorm", menuName = "Ability/Bladestorm")]
public class Bladestorm : Ability
{
    [SerializeField] private GameObject _swordTrailEffect;
    
    public override void Activate(Transform caster)
    {
        
    }
}
