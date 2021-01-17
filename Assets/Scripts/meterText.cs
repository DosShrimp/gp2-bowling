using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meterText : MonoBehaviour
{

    public GameObject text;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float meter = ball.transform.position.z * 100;
        meter = Mathf.Floor(meter) / 100;
        
        Text mText = text.GetComponent<Text>(); 

        if(meter > 0) {
            
            mText.text = (meter).ToString() + "m";
        
        } else {
            
            mText.text = "0m";

        }
        
    }
}
