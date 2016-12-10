using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility.Inspector;

public class FlyMover : MonoBehaviour
{
    public float ConstantForwardSpeed = 5;
    public float RotationSpeed = 5  ;
    //components
    private Rigidbody _rigidbody;

    //input
    private Vector3 _rotation;
	void Start()
	{
	    _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
	    float hor = Input.GetAxis("Horizontal");
	    float vert = Input.GetAxis("Vertical");

	    _rotation = new Vector3(vert, hor);
	}

    void FixedUpdate()
    {
        ApplyForwardMovement();
        ApplyRotation();
    }

    /// <summary>
    /// Applies the constant forward movement.
    /// </summary>
    private void ApplyForwardMovement()
    {
        _rigidbody.AddForce(transform.forward * ConstantForwardSpeed);
    }

    /// <summary>
    /// applies the rotation input.
    /// </summary>
    private void ApplyRotation()
    {
        transform.Rotate(_rotation * RotationSpeed);
    }
}
