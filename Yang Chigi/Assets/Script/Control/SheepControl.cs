using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepControl : MonoBehaviour {

    public GameObject leader;
    public GameObject Master;
    public Rigidbody2D rb;
    public int thrust;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    
	// Update is called once per frame
	void FixedUpdate () {
        
    }
}
