using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyType
{
    public GameObject enemy;
    public int numberOfType;
    public float interval;
    public float intervalTilNextEnemyType;
}
[CreateAssetMenu(fileName = "Wave", menuName = "Wave")]
public class WavesSO : ScriptableObject
{
    public EnemyType[] enemyType;
}
