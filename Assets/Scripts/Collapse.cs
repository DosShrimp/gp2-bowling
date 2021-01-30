using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour
{
    public bool judge = false;

    public float rotX;
    public float rotY;
    public float rotZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotX = transform.localEulerAngles.x;
        rotY = transform.localEulerAngles.y;
        rotZ = transform.localEulerAngles.z;

        if(this.GetComponent<Rigidbody>().velocity == Vector3.zero) {

            if(this.GetComponent<Rigidbody>().angularVelocity == Vector3.zero) {

                Debug.Log("aaaa");

                if((rotX > 10.0f && rotX < 350.0f) || (rotZ > 10.0f && rotZ < 350.0f)) {
                    
                    Judge();

                }

            }
        }

    }

    public void Judge() {
        judge = true;
    }
 
}
