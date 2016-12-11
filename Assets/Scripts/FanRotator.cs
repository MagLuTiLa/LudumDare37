using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotator : MonoBehaviour
{
    //Angular speed if turned on
    public float MaxAngularVelocity = .15f;
    public Vector3 Torque = new Vector3(0, 1, 0);
    //Percentual dampening when turned off;
    public bool active = true;

    //components
    private Rigidbody _rigidbody;

    public void Toggle()
    {
        active = !active;
        GetComponent<AudioSource>().enabled = active;
    }

    // Use this for initialization
    void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity= MaxAngularVelocity;
        GetComponent<AudioSource>().enabled = active;
    }
	
	// Update is called once per frame
	void Update ()
    {
        _rigidbody.maxAngularVelocity = MaxAngularVelocity;
        if (active)
            _rigidbody.AddTorque(Torque);
    }
}
