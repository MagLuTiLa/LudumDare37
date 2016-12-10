using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
    public float windSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            //Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce( * windSpeed);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            //Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
