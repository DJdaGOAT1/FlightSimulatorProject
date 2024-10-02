

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f; // Starting speed
    public float maxSpeed = 100f; // Maximum speed
    public float minSpeed = 0.1f; // Minimum speed
    public float goingupdownSpeed = 0.5f; 
    public float acceleration = 5f; // Speed increment
    public float rotSpeed = 20f;

    void Start() {
        transform.position = new Vector3(0.0f, 1.0f, 200f);
    }
    
    void Update()
    {
        // Movements
        if(Input.GetKey("w")) {
            transform.position += transform.forward * speed * Time.deltaTime; // Move forward
        }

        if(Input.GetKey("a")) {
            transform.position -= transform.right * speed * Time.deltaTime; // Move left
        }

        if(Input.GetKey("s")) {
            transform.position -= transform.forward * speed * Time.deltaTime; // Move backward
        }

        if(Input.GetKey("d")) {
            transform.position += transform.right * speed * Time.deltaTime; // Move right
        }

        // Handle speed increase and decrease
        if (Input.GetKey("z"))
        {
            speed = Mathf.Min(speed + (acceleration * Time.deltaTime), maxSpeed);
        }
        else if (Input.GetKey("x"))
        {
            speed = Mathf.Max(speed - (acceleration * Time.deltaTime), minSpeed);
        }

        // Rotations
        if (Input.GetKey("up")) // pitch axis
        {
            transform.Rotate(Vector3.left, (rotSpeed * Time.deltaTime));
        }
        if (Input.GetKey("down") && transform.position.y > 1) // pitch axis
        {
            transform.Rotate(Vector3.right, (rotSpeed * Time.deltaTime));
        }
        if (Input.GetKey("left")) // yawing
        {
            transform.Rotate(Vector3.up, -rotSpeed * Time.deltaTime); 
        }
        if (Input.GetKey("right")) // yawing
        {
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime); 
           
        }
        if (Input.GetKey("o")) {// rolling
            transform.Rotate(Vector3.forward, -rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey("p")) { // rolling
            transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
        }
        if(Input.GetKey("a") || Input.GetKey("d")) {
            transform.position += Vector3.up * Time.deltaTime;
        }
        
        else if(transform.position.y > 1) {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.position += Vector3.down * Time.deltaTime;
        }
        else if(transform.position.y <= 1 && speed > 0.2f && transform.localRotation.eulerAngles.x > 5 && transform.localRotation.eulerAngles.x < 90) {
            transform.position += transform.forward * speed * 0 * Time.deltaTime;

        }

    }
     void Explode() {
        // Implement explosion logic here
        Debug.Log("BOOM! The plane has exploded due to a crash.");
        // You can trigger particle effects, play sound, etc. here.

        // Optionally, destroy the plane gameObject
        Destroy(gameObject);
    }
}