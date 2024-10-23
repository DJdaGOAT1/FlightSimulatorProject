

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject gameObject;
    private ParticleSystem explosion;
    public Transform explosionPrefab;
    Rigidbody rb;
    public float speed = 0.0001f; // Starting speed
    public float maxSpeed = 100f; // Maximum speed
    public float minSpeed = 0.1f; // Minimum speed
    public float acceleration = 1f; // Speed increment 
    private bool explosion1; // Update is called once per frame

    void Start() {
        transform.position = new Vector3(0.0f, 1.0f, 200f);
        rb = GetComponent<Rigidbody>();
        explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
    }
    /*void OnCollisionEnter(Collision collision)
    {
        explosion1 = true;
        while(explosion1 != false) {
            if(explosion1 == true && collision.gameObject.CompareTag("whatisground") && speed > 0.2f && transform.localRotation.eulerAngles.x > 10 && transform.localRotation.eulerAngles.x < 90) 
            {
                ContactPoint contact = collision.contacts[0];
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 position = contact.point;
                explosion.Play();
                Destroy(gameObject);
            }
        }
        explosion.Stop();
        transform.position += transform.forward * speed * 0 * Time.deltaTime;
    }*/
    void FixedUpdate()
    {
        if(transform.position.y <= 1f && speed > 0.2f && transform.localRotation.eulerAngles.x > 10 && transform.localRotation.eulerAngles.x < 90) {
            var explosionDuration = explosion.main;
            explosionDuration.duration = 1f;
            explosion.Play();
        }
        // Movements
        if(Input.GetKey("w") && transform.position.y >= 0.9f) {
            speed = Mathf.Min(speed + (acceleration * Time.deltaTime), maxSpeed); // Move forward
        }

        if(Input.GetKey("a")) {
            if(transform.position.y >= 1f)
            {
                transform.Rotate(Vector3.up, -speed * Time.deltaTime); // Move left
            }
            if(transform.position.y <= 1f && transform.localRotation.eulerAngles.x >= 0 && transform.localRotation.eulerAngles.x <= 10) {
                transform.Rotate(Vector3.up, -speed * Time.deltaTime);
            }
        }

        if(Input.GetKey("s") && transform.position.y >= 0.9f) {
            speed = Mathf.Max(speed - (acceleration * Time.deltaTime), minSpeed); // Move backward
        }

        if(Input.GetKey("d")) {
            if(transform.position.y >= 1f)
            {
                transform.Rotate(Vector3.up, speed * Time.deltaTime); // Move left
            }
            if(transform.position.y <= 1f && transform.localRotation.eulerAngles.x >= 0 && transform.localRotation.eulerAngles.x <= 10) {
                transform.Rotate(Vector3.up, speed * Time.deltaTime);
            }
        }

        // Rotations
        if (Input.GetKey("up")) // pitch axis
        {
            if(transform.position.y >= 1f)
            {
                transform.Rotate(Vector3.left, speed * Time.deltaTime); 
            }
            if(transform.position.y <= 1f && transform.localRotation.eulerAngles.x >= 0 && transform.localRotation.eulerAngles.x <= 10) {
                transform.Rotate(Vector3.up, speed * Time.deltaTime);
            }
        }
        if (Input.GetKey("down") && transform.position.y > 1) // pitch axis
        {
            transform.Rotate(Vector3.right, speed * Time.deltaTime);
        }
        if (Input.GetKey("left") && transform.position.y > 1.5f) { // rolling
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        if (Input.GetKey("right") && transform.position.y > 1.5f ) {// rolling
            transform.Rotate(Vector3.forward, -speed * Time.deltaTime);
        }

        if(transform.position.y >= 0.9f && speed != 0f) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
       
    }

    
}