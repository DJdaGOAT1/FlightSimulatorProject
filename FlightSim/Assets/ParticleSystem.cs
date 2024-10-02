using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public Transform system;
    public float speed = 1f; // Starting speed
    public float maxSpeed = 100f; // Maximum speed
    public float minSpeed = 0.1f; // Minimum speed
    public float acceleration = 5f; // Speed increment

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = system.position;
        if (Input.GetKey("z"))
        {
            speed = Mathf.Min(speed + (acceleration * Time.deltaTime), maxSpeed);
        }
        if (Input.GetKey("x"))
        {
            speed = Mathf.Max(speed - (acceleration * Time.deltaTime), minSpeed);
        }
        if(system.position.y <= 1 && speed > 0.2f && system.localRotation.eulerAngles.x > 5 && system.localRotation.eulerAngles.x < 90)
        {
            ActivateParticleSystem();
        }
    }

    public void ActivateParticleSystem()
    {
        if (GetComponent<UnityEngine.ParticleSystem>() != null)
        {
            // Play the particle system
            GetComponent<UnityEngine.ParticleSystem>().Play();
        }
        else
        {
            Debug.LogError("ParticleSystem component not found.");
        }
    }
}
