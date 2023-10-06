using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MountedTurret : MonoBehaviour
{
  
    public float sensitivity = 1.0f; // Adjust this to control camera sensitivity
    public Transform rotatepoint;

    private Vector2 inputVector;
    private float rotationX = -90f;
    private float rotationY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        // Get the input from the Look action defined in the Input Actions asset
        inputVector = InputSystem.GetDevice<Mouse>().delta.ReadValue();

        //print(InputSystem.GetDevice<Mouse>().delta.ReadValue());
        //print(rotationY);
        print (rotationX);
        // Rotate the camera based on the input
        float mouseX = inputVector.x * sensitivity;
        float mouseY = inputVector.y * sensitivity;

        // Rotate the camera vertically
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -20f, 60f);
        rotationY -= mouseX;
        rotationY = Mathf.Clamp(rotationY, -50f, 50f);

        rotatepoint.localRotation = Quaternion.Euler(rotationY, 0f , 0f);

        // Rotate the player's body horizontally
        transform.localRotation = Quaternion.Euler(0f, 0f, rotationX);
    }
}



