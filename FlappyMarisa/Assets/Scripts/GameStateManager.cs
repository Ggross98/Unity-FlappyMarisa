using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    Start,
    Playing,
    Over
}

public class GameStateManager : MonoBehaviour
{
    public static GameState GameState { get; set; }

    static GameStateManager()
    {
        GameState = GameState.Playing ;
    }
}
