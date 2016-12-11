using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().time = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreditSequence()
    {
        yield return null;
    }
}
