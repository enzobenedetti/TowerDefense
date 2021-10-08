using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mobPrefab;

    [SerializeField] private float timeToSpawn = 2f;
    
    private float _timer;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = value;
            if (_timer < timeToSpawn) return;
            SpawnMob();
            _timer = 0f;
        }
    }
    
    void Update()
    {
        Timer += Time.deltaTime;
    }

    void SpawnMob()
    {
        Instantiate(mobPrefab, transform.position, Quaternion.identity);
    }
}
