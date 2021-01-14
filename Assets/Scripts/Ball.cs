using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 0.5f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAccount = speed * Time.deltaTime;

        if(Input.GetMouseButtonDown(0)) {
            rb.AddForce(transform.forward * moveAccount);
        }

    }
}
