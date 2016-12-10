using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCollisionController : MonoBehaviour
{
    public float BounceForce = 10;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = collision.contacts[0].point - transform.position;
        direction = -direction.normalized;
        _rigidbody.AddForce(direction * BounceForce);
    }
}
