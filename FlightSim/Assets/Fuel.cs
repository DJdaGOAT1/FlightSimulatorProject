using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    private ParticleSystem fuel;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        fuel = GameObject.Find("Fuel").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("z")) fuel.Play();
        else fuel.Clear();
    }
}
