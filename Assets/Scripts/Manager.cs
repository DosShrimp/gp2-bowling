using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Wall wallscript;
    public GameObject gcText;
    public float count = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wallscript.judge) {

            count -= 1 * Time.deltaTime;

            if(count < 0) {
                count = 0;
                Debug.Log("yeah");
                gcText.SetActive (true);
            }
        }

        
    }
}
