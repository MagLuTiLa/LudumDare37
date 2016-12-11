using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    public void Eaten(Collider killzone)
    {
        StopMovement();

        GameObject.Find("DeathCam").GetComponent<Camera>().enabled = true;
    }

    public void BirdFood()
    {
        StopMovement();
    }

    private void StopMovement()
    {
        GetComponent<FlyController>().enabled = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = new Vector3();
    }
}
