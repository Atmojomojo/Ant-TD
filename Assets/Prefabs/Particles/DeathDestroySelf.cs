using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDestroySelf : MonoBehaviour
{
    private float timeStamp; 
    public float timeAlive;
    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time + timeAlive;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeStamp)
        {
            Destroy(gameObject);
        }
    }
}
