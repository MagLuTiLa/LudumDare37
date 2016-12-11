using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    bool isPlaying;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isPlaying && collision.transform.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            isPlaying = true;
        }
    }
}
