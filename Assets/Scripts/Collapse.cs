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
        if(this.GetComponent<Rigidbody>().IsSleeping()) {

            if(transform.localEulerAngles.x > 30.0f || transform.localEulerAngles.z > 30.0f || transform.localEulerAngles.x < -30.0f || transform.localEulerAngles.z < -30.0f) {

                judge = true;

            }
        
        }

    }

    void OnCollisionEnter(Collision collision) {

        Debug.Log(collision.relativeVelocity.magnitude);
        // if(collision.gameObject.tag != "Plane") {
        //     judge = true;
        // }
    }
 
}
