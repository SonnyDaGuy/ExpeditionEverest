using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    SinglePlayer = 1,
    LocalCoop = 2
}

public static class CurrentGameMode
{
    public static GameMode gameMode { get; private set; }
    
    public static void SetGameMode(GameMode gameModeWanted)
    {
        gameMode = gameModeWanted;
    }
}
