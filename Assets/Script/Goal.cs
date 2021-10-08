using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private static Vector3 _goalPosition;
    public static Vector3 GoalPosition
    {
        get => _goalPosition;
        set => _goalPosition = value;
    }

    private void Awake()
    {
        GoalPosition = this.transform.position;
    }
}
