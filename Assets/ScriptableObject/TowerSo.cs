using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower")]
public class TowerSo : ScriptableObject
{
    public string name;
    public float range;
    public int damage;
    public float coolDown;
    public int cost;
}
