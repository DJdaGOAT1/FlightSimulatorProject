

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f; // Starting speed
    public float maxSpeed = 100f; // Maximum speed
    public float minSpeed = 1f; // Minimum speed
    public float goingupdownSpeed = 0.5f; 
    public float acceleration = 5f; // Speed increment
    public float rotSpeed = 20f;

    void Start() {
        transform.position = new Vector3(0.0f, 1.0f, 200f);
    }
    
    void Update()
    {
        // Movements
        if(Input.GetKey(KeyCode.W)) {
            transform.position += transform.forward * speed * Time.deltaTime; // Move forward
        }

        if(Input.GetKey(KeyCode.A)) {
            transform.position -= transform.right * speed * Time.deltaTime; // Move left
        }

        if(Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * speed * Time.deltaTime; // Move backward
        }

        if(Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * speed * Time.deltaTime; // Move right
        }

        // Handle speed increase and decrease
        if (Input.GetKey(KeyCode.Z))
        {
            speed = Mathf.Min(speed + (acceleration * Time.deltaTime), maxSpeed);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            speed = Mathf.Max(speed - (acceleration * Time.deltaTime), minSpeed);
        }

        // Rotations
        if (Input.GetKey(KeyCode.UpArrow)) // pitch axis
        {
            if(Input.GetKey(KeyCode.W)) {
               transform.Rotate(Vector3.left, (rotSpeed * Time.deltaTime)); 
            }
            else {
                transform.Rotate(Vector3.left, (rotSpeed * Time.deltaTime));
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        
        if (Input.GetKey(KeyCode.DownArrow)) // pitch axis
        {
            if(Input.GetKey(KeyCode.S)) {
               transform.Rotate(Vector3.right, (rotSpeed * Time.deltaTime)); 
            }
            else {
                transform.Rotate(Vector3.right, (rotSpeed * Time.deltaTime));
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // yawing
        {
            if(Input.GetKey(KeyCode.A)) {
               transform.Rotate(Vector3.up, (-rotSpeed * Time.deltaTime)); 
            }
            else {
                transform.Rotate(Vector3.up, -rotSpeed * Time.deltaTime); 
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) // yawing
        {
           if(Input.GetKey(KeyCode.D)) {
               transform.Rotate(Vector3.up, (rotSpeed * Time.deltaTime)); 
            }
           else {
               transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime); 
               transform.position += transform.forward * speed * Time.deltaTime;
           }
        }
        if (Input.GetKey(KeyCode.O)) { // rolling
            transform.Rotate(Vector3.forward, -rotSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.P)) { // rolling
            transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        else if(transform.position.y > 1) {
            transform.position += transform.forward * (speed) * Time.deltaTime;
            transform.position += Vector3.down * Time.deltaTime;
        }
        /*if (transform.position.y > 0)
        {
            transform.position += Vector3.down * 9.81f * Time.deltaTime; // Applying gravity
        }*/
    }
}