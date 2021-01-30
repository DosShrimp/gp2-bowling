using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    Collapse collapse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collapse = transform.parent.GetComponent<Collapse>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Plane") {

            Debug.Log("すり抜けた！");
            collapse.Judge();
        
        }
    }

}
