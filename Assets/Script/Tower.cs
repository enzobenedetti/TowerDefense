using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float lookDistance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var mob in Mob.Mobs)
        {
            if (Vector3.Distance(transform.position, mob.transform.position) < lookDistance)
            {
                transform.LookAt(mob.transform);
            }
        }
    }
}
