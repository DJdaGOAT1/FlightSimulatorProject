using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Collision collision;
    // Update is called once per frame
    
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("whatisground")) 
        {
            Destroy(gameObject);
        }
    }
}
