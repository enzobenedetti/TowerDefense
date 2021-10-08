using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static GameObject GoalReference;
    public static List<Goal> Goals = new List<Goal>();

    private Vector3 _goalPosition;
    public Vector3 GoalPosition
    {
        get => _goalPosition;
        set => _goalPosition = value;
    }

    private int _goalHealth;
    public int GoalHealth
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
        Goals.Add(this);
        GoalReference = this.gameObject;
        GoalPosition = this.transform.position;
        GoalHealth = 5;
    }

    private void OnDestroy()
    {
        Goals.Remove(this);
    }
}
