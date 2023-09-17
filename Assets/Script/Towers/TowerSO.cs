using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Tower", menuName = "Tower")]
public class TowerSO : ScriptableObject
{
    public float range;
    public float damage;
    public float attackspeed;
    public bool hasCooldown;
    public float cooldownTime;
    public string specialEffect;
}
