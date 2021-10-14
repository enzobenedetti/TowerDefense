using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    private NavMeshAgent agent;
    public static List<Mob> Mobs = new List<Mob>();
    

    private bool isDead;
    private Goal goalAimed;

    private int killPrize = 1;
    
    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            if (_health > 0) return;
            _health = 0;
            isDead = true;
        }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Mobs.Add(this);
        Health = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var goal in Goal.Goals)
        {
            if (!goalAimed)
                goalAimed = goal;
            else if (Vector3.Distance(transform.position, goal.GoalPosition) <
                     Vector3.Distance(transform.position, goalAimed.GoalPosition))
                    goalAimed = goal;
        }
        agent.SetDestination(goalAimed.GoalPosition);
    }

    private void Update()
    {
        if (GameManager.GameActualState == GameManager.GameState.GameOver)
                 agent.ResetPath();
        else if (Vector3.Distance(transform.position, goalAimed.GoalPosition) < 2f)
        {
            Destroy(this.gameObject);
            goalAimed.GoalHealth--;
        }
        
        if (isDead) Destroy(this.gameObject);
    }

    public static void GetDamage(Mob mob, int damage)
    {
        mob.Health -= damage;
    }

    private void OnDestroy()
    {
        if (isDead) 
        {
            Money.Amount += killPrize;
            UpdateScore.AddScore();
        }
        Mobs.Remove(this);
    }
}
