

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject gameObject;
    public Camera thirdperson;
    public Camera firstperson;
    public Camera front;
    public Camera activeCamera;
    private int camCount = 1;
    private ParticleSystem explosion;
    private ParticleSystem postExplosion;
    Rigidbody Rb;
    public float speed = 0.0001f; // Starting speed
    public float maxSpeed = 100f; // Maximum speed
    public float minSpeed = 0.1f; // Minimum speed
    public float acceleration = 1f; // Speed increment 
    private bool isStopforExplosion; // Update is called once per frame


    void Start() {
        transform.position = new Vector3(0.0f, 1.0f, 200f);
        Rb = GetComponent<Rigidbody>();
        explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        postExplosion = GameObject.Find("PostExplosion").GetComponent<ParticleSystem>();
        isStopforExplosion = false;
        SetCameraView(camCount);
    }
    
    void FixedUpdate() {
        if (Input.GetKeyDown("c"))
        {
            SwitchCamera();
        }
        if (Input.GetKeyDown("q")) 
        {
            GoToScene();
        }
        if(transform.position.y <= 1f && isStopforExplosion == false && speed > 0.2f && transform.localRotation.eulerAngles.x > 10 && transform.localRotation.eulerAngles.x < 90) {
            isStopforExplosion = true;
            explosion.Play();
            transform.position += transform.forward * speed * 0 * Time.deltaTime;
            postExplosion.Play();
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
    private void SwitchCamera()
    {
        camCount++;

        // Loop back to the first camera if we exceed the last
        if (camCount > 3)
        {
            camCount = 1; // Reset to third-person
        }

        SetCameraView(camCount);
    }

    private void GoToScene() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void SetCameraView(int newCamCount)
    {
        // Disable the active camera
        if (activeCamera != null)
        {
            activeCamera.enabled = false;
        }

        // Set the new camera to be active
        switch (newCamCount)
        {
            case 1:
                activeCamera = thirdperson;
                break;
            case 2:
                activeCamera = firstperson;
                break;
            case 3:
                activeCamera = front;
                break;
        }

        // Enable the new active camera
        if (activeCamera != null)
        {
            activeCamera.enabled = true;
        }
    }  
}