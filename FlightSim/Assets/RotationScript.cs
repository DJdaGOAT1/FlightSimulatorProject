using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotSpeed = 10f; // Rotation speed
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotSpeed * Time.deltaTime); // Rotate left
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime); // Rotate right
        }

        if(Input.GetKey(KeyCode.Space)) {
            transform.Rotate(Vector3.left, (rotSpeed * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.right, (rotSpeed * Time.deltaTime));
        }
    }
}
