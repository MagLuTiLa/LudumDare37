using UnityEngine;
using UnityEngine.Networking;

public class FlyMover : MonoBehaviour
{
    public float FlapForwardSpeed = 5;
    public float FlapUpwardSpeed = 5;

    public float RotationSpeed = 5;

    public float MinVelocity = 0.05f;

    //components
    private Rigidbody _rigidbody;

    //input
    private float _horRotation;
    private float _vertRotation;
    private bool _shouldFlap;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        //flappy upward input
        _shouldFlap = Input.GetKeyDown(KeyCode.Space);

        //rotation input
        _horRotation += Input.GetAxis("Horizontal")*RotationSpeed;
        _vertRotation += Input.GetAxis("Vertical")*RotationSpeed;
    }

    void FixedUpdate()
    {
        if(_shouldFlap)
            Flap();

        ApplyRotation();
        CapVelocity();
    }

    private void CapVelocity()
    {
        if (_rigidbody.velocity.magnitude < MinVelocity)
            _rigidbody.velocity =Vector3.zero;
    }

    /// <summary>
    /// Applies the constant forward movement.
    /// </summary>
    private void Flap() 
    {
        _rigidbody.AddForce(transform.up * FlapUpwardSpeed);
        _rigidbody.AddForce(transform.forward * FlapForwardSpeed);
    }

    /// <summary>
    /// applies the rotation input.
    /// </summary>
    private void ApplyRotation()
    {
        transform.localRotation = Quaternion.Euler(_vertRotation, _horRotation, 0);
    }
}
