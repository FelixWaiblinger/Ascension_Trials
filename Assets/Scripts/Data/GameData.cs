using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    public Ability Attack;
    public Ability Special;
    public Ability Ultimate;
}
