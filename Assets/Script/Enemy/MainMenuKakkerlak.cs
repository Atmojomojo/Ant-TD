using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuKakkerlak : MonoBehaviour
{
    public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-7,0,0);
    }

    public void OnTriggerEnter(Collider other)
    {
        gameObject.transform.position = respawnPoint.position;
    }
}
