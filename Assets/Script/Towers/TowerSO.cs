using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Tower", menuName = "Tower")]
public class TowerSO : ScriptableObject
{
    public float range, range1, range2, range3;
    public float damage, damage1, damage2, damage3;
    public float attackspeed;
    public bool hasCooldown;
    public float cooldownTime;
    public string specialEffect;
    public float cost, upCost2, upCost3;
}
