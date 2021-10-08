using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    private NavMeshAgent agent;
    public static List<Mob> Mobs = new List<Mob>();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Mobs.Add(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(Goal.GoalPosition);
    }

    private void Update()
    {
        if (GameManager.GameActualState == GameManager.GameState.GameOver)
                 agent.ResetPath();
        else if (Vector3.Distance(transform.position, Goal.GoalPosition) < 2f)
        {
            Destroy(this.gameObject);
            Goal.GoalHealth--;
        }
    }

    private void OnDestroy()
    {
        Mobs.Remove(this);
    }
}
