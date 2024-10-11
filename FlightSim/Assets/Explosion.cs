using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private ParticleSystem explosion;
    public GameObject gameObject;
    public float speed = 1f; // Starting speed
    public float maxSpeed = 100f; // Maximum speed
    public float minSpeed = 0.1f; // Minimum speed
    public float acceleration = 5f; // Speed increment

    void Start()
    {
        explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 1 && speed > 0.2f && transform.localRotation.eulerAngles.x > 0 && transform.localRotation.eulerAngles.x < 90) 
        {
            explosion.Play();
        }
        else explosion.Stop();
    }
}
