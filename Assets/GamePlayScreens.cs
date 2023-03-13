using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameScreens
{
    GamePlay,
    Pause,
    LevelComplete,
    LevelFailed,
    Loading
}
public class GamePlayScreens : Singleton<GamePlayScreens>
{
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
