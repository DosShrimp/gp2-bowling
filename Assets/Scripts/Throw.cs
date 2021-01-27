using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    public GameObject meter;
    public GameObject navi;
    public RectTransform rt;

    public float speed = 0.5f;
    public float count_speed = 0.5f;
    public float count = 0.0f;
    bool isClicked1 = false;
    bool isClicked2 = false;
    bool isClicked3 = false;
    public bool throwed = false;
    public bool arrived = false;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rt = meter.GetComponent(typeof (RectTransform)) as RectTransform;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveAccount = speed * Time.deltaTime;
        float count_speedAccount = count_speed * Time.deltaTime;
        

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

        } else if(!isClicked3) {
        
            count += count_speedAccount;
            rt.sizeDelta = new Vector2 (120, Mathf.Abs(Mathf.Sin(count*10))*100); 

            if(Input.GetKeyDown("space")) {

                isClicked3 = true;
            }   

        } else {

            throwed = true;

            if(transform.position.z < 90.0f) {
                
                transform.position += transform.forward * (moveAccount + rt.sizeDelta.y/1000);
            
            } else {

                arrived = true;
            
            } 

        }
    }

    public void Reset() {

        rb.velocity = Vector3.zero;
        
        count = 0.0f;

        isClicked1 = false;
        isClicked2 = false;
        isClicked3 = false;

        throwed = false; 
        arrived = false;        

        transform.position = new Vector3(0, 1, -28);
        transform.rotation = Quaternion.identity;


        navi.GetComponent<Navigate>().isClicked1 = false;
        navi.GetComponent<Navigate>().isClicked2 = false;

        navi.transform.position = new Vector3(0, 0, -28.0f);
        navi.transform.rotation = Quaternion.identity;

        rt.sizeDelta = new Vector2 (120, 10);
    }
}
