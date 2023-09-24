using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "Character", menuName = "Game/Character")]
public class Character : ScriptableObject
{
    public string Name;
    public float Health;
    public float Armor;
    public float Speed;
    public SerializedDictionary<Slot, Ability> Abilities;
    public GameObject Visuals;
}
