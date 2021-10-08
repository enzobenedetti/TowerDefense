using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState
    {
        InGame,
        GameOver
    }

    public static GameState GameActualState = GameState.InGame;

    public static List<GameObject> GameOverGo = new List<GameObject>();
    
    void Awake()
    {
        GameOverGo.Add(GameObject.FindGameObjectWithTag("GameOver"));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameActualState == GameState.GameOver)
        {
            foreach (var obj in GameOverGo)
            {
                obj.SetActive(true);
            }
        }
    }
}
