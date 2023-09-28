using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class CameraLookAt : MonoBehaviour
{
    public float moveSpeed;
    public GameObject cameraLookAt;
    public bool left, right;

    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraLookAt.transform.position);
        if (left == true)
        {
            Vector3 velocity = -transform.right * moveSpeed * Time.deltaTime;
            transform.position += velocity;
        }
        if (right == true)
        {
            Vector3 velocity = transform.right * moveSpeed * Time.deltaTime;
            transform.position += velocity;
        }
    }

    public void LeftMove()
    {
        left = !left;
    }

    public void RightMove()
    {
        right = !right;
    }
}
