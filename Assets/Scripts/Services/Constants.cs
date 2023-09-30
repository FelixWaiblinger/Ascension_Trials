using System.Collections.Generic;

public class Constants
{
    public const string JoinKey = "j";
    public const string DifficultyKey = "d";
    public const string GameTypeKey = "t";

    public static readonly List<string> PlayerCounts = new() { "1", "2", "4" };
    public static readonly List<string> Difficulties = new() { "Easy", "Normal", "Hard", "Godlike" };
}