using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform camera;
    public Vector3 myPos;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position = camera.position + myPos;
        

        //transform.forward = cameraPosition.forward;
        
    }
}
