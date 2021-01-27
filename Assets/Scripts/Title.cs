using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public GameObject text;
    RectTransform rt;
    float count = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        rt = text.GetComponent(typeof (RectTransform)) as RectTransform;
        
    }

    // Update is called once per frame
    void Update()
    {   

        count += 0.01f;

        rt.anchoredPosition = new Vector3(0, Mathf.Sin(count) * 7.0f, 0);

        if(Input.GetKeyDown("space")) {

            SceneManager.LoadScene("Game");
            
        }
        
    }
}
