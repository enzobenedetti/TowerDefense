using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float lookDistance = 5f;
    [SerializeField] private float coolDown = 1f;
    [SerializeField] private GameObject bulletPrefab;
    GameObject bullet;
    LineRenderer line;
    public static int towerCost = 10;
    
    private float _timer;
    public float Timer
    {
        get => _timer;
        set
        {
            _timer = value;
            if(_timer >= 0.1f && bullet) Destroy(bullet);
            if (_timer <= coolDown) return;
            if (mobLocked)
            {
                _timer = 0f;
                Shoot();
                return;
            }
        }
    }

    private bool mobLocked = false;
    private Mob mobRef;

    // Update is called once per frame
    void Update()
    {
        if (mobLocked && mobRef && Vector3.Distance(transform.position, mobRef.transform.position) < lookDistance)
        {
            transform.LookAt(mobRef.transform.position);
        }
        else
        {
            mobRef = null;
            mobLocked = false;
            foreach (var mob in Mob.Mobs)
            {
                if (!mobLocked && Vector3.Distance(transform.position, mob.transform.position) < lookDistance)
                {
                    transform.LookAt(mob.transform);
                    mobRef = mob;
                    mobLocked = true;
                }
                else if (mobLocked) break;
            }
        }
        Timer += Time.deltaTime;
    }

    private void Shoot()
    {
        bullet = Instantiate(bulletPrefab);
        line = bullet.GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        line.SetPosition(1, mobRef.transform.position);
        Mob.GetDamage(mobRef, 1);
    }
}
