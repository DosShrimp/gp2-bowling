using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigate : MonoBehaviour
{
    public float speed = 0.5f;
    float count = 0.0f;
    public bool isClicked1 = false;
    public bool isClicked2 = false;
    public GameObject yajirusi;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveAccount = speed * Time.deltaTime;
                
        if(!isClicked1) {

            if(Input.GetKeyDown("space")) {
                isClicked1 = true;
            }

            if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 10.0f) {
                transform.position += new Vector3(moveAccount/2, 0, 0);
            } 

            if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -10.0f) {
                transform.position += new Vector3(-moveAccount/2, 0, 0);
            }

        } else if(!isClicked2) {

            if(Input.GetKey(KeyCode.RightArrow) && (transform.localEulerAngles.y < 30.0f || transform.localEulerAngles.y > 325.0f)) {
                transform.Rotate(0, moveAccount, 0);
            } 

            if(Input.GetKey(KeyCode.LeftArrow) && (transform.localEulerAngles.y > 330.0f || transform.localEulerAngles.y < 35.0f)) {
                transform.Rotate(0, -moveAccount, 0);
            }
            
            if(Input.GetKeyDown("space")) {

                isClicked2 = true;
            }

        }

    }
}
