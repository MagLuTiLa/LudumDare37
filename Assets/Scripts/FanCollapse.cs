using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCollapse : MonoBehaviour {

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    //components
    private Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _rigidbody.useGravity = true;
            _rigidbody.constraints = 0;
        }
    }
}
