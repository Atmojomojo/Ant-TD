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
        if (left == true)
        {
            cameraLookAt.transform.Rotate(0, moveSpeed * Time.deltaTime, 0);
        }
        if (right == true)
        {
            cameraLookAt.transform.Rotate(0, -moveSpeed * Time.deltaTime, 0);
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
