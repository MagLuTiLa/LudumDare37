using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    public void Eaten(Collider killzone)
    {
        GetComponent<FlyController>().enabled = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = new Vector3();

        GameObject.Find("DeathCam").GetComponent<Camera>().enabled = true;
    }
}
