using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public static float timeWave = 30f;
    public static int wave = 1;
    private static float _timer = 0f;
    public static float Timer
    {
        get => _timer;
        set
        {
            _timer = value;
            if (_timer < timeWave) return;
            _timer = 0f;
            EndWave();
            wave++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
    }

    private static void EndWave()
    {
        foreach (var mob in Mob.Mobs)
        {
            Destroy(mob.gameObject);
        }
    }
}
