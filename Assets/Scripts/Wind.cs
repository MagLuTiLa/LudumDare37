using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
    public float windSpeed = 50;
    private float tubeLenght;
    private Vector3 beginTube;

	// Use this for initialization
	void Start () {
        tubeLenght = transform.localScale.y;
        beginTube = transform.position - (transform.up * (tubeLenght / 2));
	}

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            Vector3 playerDistance = col.transform.position - beginTube;
            rb.AddForce(transform.up * Mathf.Lerp(windSpeed, 0, playerDistance.magnitude / tubeLenght));
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
