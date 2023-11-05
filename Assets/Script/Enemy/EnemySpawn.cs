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
    private bool lastWaveSend;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject winScreen;
    // Update is called once per frame
    void Update()
    {
        if (wave.enemyType[currentWave].numberOfType > numberSend)
        {
            if (Time.time > timeStamp)
            {
                enemies.Add(Instantiate(wave.enemyType[currentWave].enemy, gameObject.transform.position, gameObject.transform.rotation));
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
                timeStamp = Time.time + 9999999999999999999;
                lastWaveSend = true;
                currentWave = 0;
               
            }
        }
        if (lastWaveSend == true)
        {
            if (enemies.Count == 0)
            {
                winScreen.SetActive(true);
                Debug.Log("You've won");
            }
        }
    }
}
