using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 20;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText(health.ToString());
        if (health <= 0)
        {
            Debug.Log("Game Over You Lost!!!");
        }
    }
}
