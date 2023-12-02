﻿using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    public float verticalSpeed = 5f;
    public float maxY = 10f; 
    public float minY = 0f;
    

    [Header("Running")]
    public bool canRun = true;

    


    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        
    }
    void Update()
    {
        // Get the vertical input axis (W for up, S for down, or customize as needed)
        float verticalInput = Input.GetAxis("Vertical1");

        // Calculate the new position based on the input
        float newY = Mathf.Clamp(transform.position.y + verticalInput * verticalSpeed * Time.deltaTime, minY, maxY);

        // Update the position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    

    


}