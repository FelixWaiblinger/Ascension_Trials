using System;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "SaveData", menuName = "Data/Save Data")]
[Serializable]
public class SaveData : ScriptableObject
{
    public OptionData SavedOptions;
    public StatisticData SavedStatistics;
}

[Serializable]
public struct StatisticData
{
    public float PlayTime; // overall
    public float[] BestClearTime; // per difficulty
    public int[] DifficultyCounts;
    public SerializedDictionary<string, CharacterData> Characters;
}

[Serializable]
public struct CharacterData
{
    public int TimesPlayed;
    public float DamageDealt;
    public float DamageTaken;
    public float DamageMitigated;
    public float DamageHealed;
}
