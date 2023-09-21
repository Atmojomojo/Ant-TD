using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public WavesSO wave;
    public int numberSend; 
    public float timeStamp;
    public int currentWave;
    public bool infinite = false;
    // Update is called once per frame
    void Update()
    {
        if (wave.enemyType[currentWave].numberOfType > numberSend)
        {
            if (Time.time > timeStamp)
            {
                Instantiate(wave.enemyType[currentWave].enemy, gameObject.transform.position, gameObject.transform.rotation);
                numberSend += 1;
                timeStamp = Time.time + wave.enemyType[currentWave].interval;
            }
        }
        if (wave.enemyType[currentWave].numberOfType == numberSend)
        {
            timeStamp = Time.time + wave.enemyType[currentWave].intervalTilNextEnemyType;
            currentWave += 1;
            numberSend = 0;
        }
        if (infinite == true)
        {
            if (wave.enemyType.Length == currentWave)
            {
                currentWave = 0;
            }
        }
        else
        {
            if (wave.enemyType.Length == currentWave)
            {
                //
            }
        }
    }
}
