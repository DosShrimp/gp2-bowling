using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour
{
    public bool judge = false;

    float z1;
    float z2;
    float x1;
    float x2;

    // Start is called before the first frame update
    void Start()
    {
        z1 = transform.position.z + 5.0f;
        z2 = transform.position.z - 5.0f;
        x1 = transform.position.x + 5.0f;
        x2 = transform.position.x - 5.0f;

    }

    // Update is called once per frame
    void Update()
    {
        // if(transform.position.z > z1 || transform.position.z < z2 || transform.position.x > x1 || transform.position.x < x2) {
        //     Debug.Log("WowWow");
        //     judge = true;
        // }

    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag != "Plane") {
            judge = true;
        }
    }// Start is called before the first frame update
 
}
