using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
    public float windSpeed = 300;
    public bool active = true;
    private float tubeLenght;
    private Vector3 beginTube;
    private AudioSource windSound;

	// Use this for initialization
	void Start () {
        tubeLenght = transform.lossyScale.y;
        beginTube = transform.position - (transform.up * (tubeLenght / 2));
        windSound = GetComponentInParent<AudioSource>();
	}

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && active)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            Vector3 playerDistance = col.transform.position - beginTube;
            rb.AddForce(transform.up * Mathf.Lerp(windSpeed, 0, playerDistance.magnitude / tubeLenght));
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player" && active)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
	
    public void Toggle()
    {
        active = !active;
    }

    void SoundManager()
    {
        if (!active)
        {
            windSound.volume = 0f;
        }
        else
        {
            windSound.volume = 1f;
        }
    }

	// Update is called once per frame
	void Update () {
        SoundManager();
    }
}
