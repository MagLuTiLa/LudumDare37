using UnityEngine;
using UnityEngine.Networking;

public class FlyMover : MonoBehaviour
{
    public float ConstantForwardSpeed = 5;
    public float RotationSpeed = 5  ;
    //components
    private Rigidbody _rigidbody;

    //input
    private Quaternion _rotation;
	void Start()
	{
	    _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal")*RotationSpeed;
        float vert = Input.GetAxis("Vertical")*RotationSpeed;

        _rotation = Quaternion.Euler(vert, hor, 0);
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
        transform.localRotation *= _rotation;

    }
}
