using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static GameObject GoalReference;
    
    private static Vector3 _goalPosition;
    public static Vector3 GoalPosition
    {
        get => _goalPosition;
        set => _goalPosition = value;
    }

    private static int _goalHealth;
    public static int GoalHealth
    {
        get => _goalHealth;
        set
        {
            _goalHealth = value;
            if (_goalHealth > 0) return;
            GameManager.GameActualState = GameManager.GameState.GameOver;
            Destroy(GoalReference);
        }
    }

    private void Awake()
    {
        GoalReference = this.gameObject;
        GoalPosition = this.transform.position;
        GoalHealth = 5;
    }
}
