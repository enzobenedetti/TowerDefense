using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public enum GameState
    {
        InGame,
        GameOver
    }

    private static GameState _gameActualState = GameState.InGame;
    public static GameState GameActualState
    {
        get => _gameActualState;
        set
        {
            _gameActualState = value;
            ChangeScene();
        }
    }

    static void ChangeScene()
    {
        switch (GameActualState)
        {
            case GameState.GameOver:
                SceneManager.LoadScene(1);
                break;
            case GameState.InGame:
                SceneManager.LoadScene(0);
                Money.Amount = 20;
                break;
        }
    }
}
