using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour {

    public float thrust;
    public Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(transform.up * thrust);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(transform.up * -thrust);
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(transform.right * -thrust);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(transform.right * thrust);
    }
}
