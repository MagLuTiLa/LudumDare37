using UnityEngine;
using UnityEngine.Networking;

public class FlyMover : MonoBehaviour
{
    public float ConstantForwardSpeed = 5;
    public float RotationSpeed = 5;
    //components
    private Rigidbody _rigidbody;

    //input
    private float _horRotation = 0;
    private float _vertRotation = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _horRotation += Input.GetAxis("Horizontal")*RotationSpeed;
        _vertRotation += Input.GetAxis("Vertical")*RotationSpeed;
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
        _rigidbody.AddForce(transform.forward*ConstantForwardSpeed);
    }

    /// <summary>
    /// applies the rotation input.
    /// </summary>
    private void ApplyRotation()
    {
        transform.localRotation = Quaternion.Euler(_vertRotation, _horRotation, 0);
    }
}
