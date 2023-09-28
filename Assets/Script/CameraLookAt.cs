using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class CameraLookAt : MonoBehaviour
{
    public float moveSpeed;
    public GameObject cameraLookAt;

    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraLookAt.transform.position);
    }

    public void LeftMove()
    {
        Vector3 velocity = -transform.right * moveSpeed * Time.deltaTime;
        transform.position += velocity;
    }

    public void RightMove()
    {
        Vector3 velocity = transform.right * moveSpeed * Time.deltaTime;
        transform.position += velocity;
    }
}
