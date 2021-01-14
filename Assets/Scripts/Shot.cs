using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{

    public float speed = 0.5f;
    public Rigidbody rb;
    public RectTransform rt;

    bool isClicked1 = true;
    bool isClicked2 = false;

    public GameObject meter;
    public GameObject power_meter;

    bool changeRotate;
    float rotate;
    float angle;
    float count = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rt = power_meter.GetComponent (typeof (RectTransform)) as RectTransform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAccount = speed * Time.deltaTime;

        rt.sizeDelta = new Vector2 (120, Mathf.Abs(Mathf.Sin(count))*100);

        if(isClicked1) {
            count += 0.005f;
            
        } else if(isClicked2) {
            Meter();
        }
        
        

        if(Input.GetMouseButtonDown(0)) {
            if(isClicked1) {

                isClicked2 = true;
                isClicked1 = false;

            } else if(isClicked2) {
                rb.AddForce(transform.forward * moveAccount);
                speed = ((rt.sizeDelta.y / 100) * 300000) + 200000;

                isClicked2 = false;
            }
        }

        
    }

    void Meter() {

        //角度が0.1度以下になるとtureになる
        if(0.1f >= meter.transform.eulerAngles.z) {
            changeRotate = true;
        }

        //90度以上になるとfalseに切り替わる
        if(90 <= meter.transform.eulerAngles.z) {
            changeRotate = false;
        }

        //trueなら角度を1足す、falseなら-1足す
        if(changeRotate) {
            rotate = 0.1f;
        } else {
            rotate = -0.1f;
        }

        meter.transform.Rotate(0, 0, rotate);
        angle = meter.transform.eulerAngles.z;

        //メーターのz軸の角度をボールのx軸の角度に、-1かけるとちょうどいい
        transform.rotation = Quaternion.Euler(angle * -1, 0, 0);

    }


}
