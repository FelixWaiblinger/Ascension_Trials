using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    public SerializedDictionary<ulong, Character> Players;
}
