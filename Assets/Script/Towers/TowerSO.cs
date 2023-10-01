using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Tower", menuName = "Tower")]
public class TowerSO : ScriptableObject
{
    public float range1, range2, range3;
    public float damage1, damage2, damage3;
    public float attackspeed;
    public float cooldownTime;
    public float cost, upCost2, upCost3;
}
