﻿using UnityEngine;
using System.Collections;

public class CameraOrbitWithZoom : MonoBehaviour
{

    public Transform target;
    public float distance = 5.0f;
    public float panSpeed = 5f;
    public float sensitivity = 1f;
    
    public float distanceMin = .5f;
    public float distanceMax = 15f;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            HideCursor(true);
            Rotate();
        }
        else if(Input.GetMouseButton(2))
        {
            HideCursor(true);
            Pan();
        }
        else
        {
            HideCursor(false);
        }

        Movement();
    }

    void Rotate()
    {
        x += Input.GetAxis("Mouse X") * sensitivity;
        y -= Input.GetAxis("Mouse Y") * sensitivity;
    }

    void Movement()
    {
        // Check if a target has been set
        if (target)
        {
            // Convert x and y rotations to Quaternion using Euler
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            
            //distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            // Calculate new position offset using rotation
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            // Apply rotation and position to transform
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    void Pan()
    {
        float inputX = -Input.GetAxis("Mouse X");
        float inputY = -Input.GetAxis("Mouse Y");

        Vector3 movement = transform.TransformDirection(new Vector3(inputX, inputY));
        target.transform.position += movement * panSpeed * Time.deltaTime;
    }

    void HideCursor(bool isHiding)
    {
        if (isHiding)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void GetInput()
    {
        // Gather X and Y mouse offset input to rotate camera (by sensitivity)
        x += Input.GetAxis("Mouse X") * sensitivity;
        // Opposite direction for Y because it is inverted
        y -= Input.GetAxis("Mouse Y") * sensitivity;

        // Get Mouse ScrollWheel input offset for changing distance
        float inputScroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - inputScroll, distanceMin, distanceMax);
    }
}
