using UnityEngine;
using UnityEngine.Networking;

public class FlyController : MonoBehaviour
{
    public float MaxForwardSpeed = 5;
    public float FlapUpwardSpeed = 5;

    public float RotationSpeed = 5;

    public float MinVelocity = 0.05f;

    //components
    private Rigidbody _rigidbody;
    private FlyingSoundController _flyingSound;

    //input
    private float _horRotation;
    private float _vertRotation;
    private float _forwardSpeed;
    private bool _shouldFlap;

    public bool isGrounded;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _flyingSound = GetComponent<FlyingSoundController>();

        _forwardSpeed = MaxForwardSpeed;

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        isGrounded = IsGrounded();
    }

    private void ReadInput()
    {
        //flappy upward input
        _shouldFlap = Input.GetKey(KeyCode.Space);

        //rotation input
        _horRotation += Input.GetAxis("Mouse X") * RotationSpeed;
        _vertRotation -= Input.GetAxis("Mouse Y") * RotationSpeed;

        //exit game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        if (_shouldFlap)
            Flap();

        ApplyRotation();
        if (!IsGrounded())
        {
            _flyingSound.Play();
            ApplySpeed();
        }
        else
            StopMoving();
    }

    private void CapVelocity()
    {
        if (_rigidbody.velocity.magnitude < MinVelocity)
            _rigidbody.velocity = Vector3.zero;
    }

    /// <summary>
    /// Applies the constant forward movement.
    /// </summary>
    private void Flap()
    {
        _rigidbody.AddForce(transform.up * FlapUpwardSpeed);
    }

    /// <summary>
    /// applies the rotation input.
    /// </summary>
    private void ApplyRotation()
    {
        transform.rotation = Quaternion.Euler(_vertRotation, _horRotation, 0);
    }

    private void ApplySpeed()
    {
        _forwardSpeed = Mathf.Clamp(_forwardSpeed + 5, 1, MaxForwardSpeed);
        _rigidbody.AddForce(transform.forward * _forwardSpeed);
    }

    private void StopMoving()
    {
        _rigidbody.velocity = Vector3.zero;
        _forwardSpeed = 0;

        if (_flyingSound.IsPlaying)
            _flyingSound.FadeOut(0.2f);
    }

    private void Bump()
    {
        _rigidbody.AddForce(-transform.forward * 10, ForceMode.Impulse);
        _forwardSpeed = 0;
        SoundManager.PlaySound("Pok", Random.Range(0.8f, 1.2f), 2);
    }

    bool IsGrounded()
    {
        RaycastHit hitInfo;
        Physics.Raycast(transform.position, Vector3.down, out hitInfo, GetComponent<SphereCollider>().radius / 2);

        return hitInfo.collider != null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null && !IsGrounded())
        {
            Bump();
        }
    }
}
