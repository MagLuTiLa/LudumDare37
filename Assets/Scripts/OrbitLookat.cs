using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitLookat : MonoBehaviour {

    [SerializeField]
    GameObject fly;

    float distance;
    float time = 0.0f;

    [SerializeField]
    float factor = 1.0f;

	// Use this for initialization
	void Start () {
        distance = Vector3.Distance(fly.transform.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        float x = distance * Mathf.Cos(time * factor);
        float z = distance * Mathf.Sin(time * factor);
        Vector3 offset = new Vector3(x, 0, z);
        transform.position = fly.transform.position + offset;

        transform.rotation = Quaternion.LookRotation(-offset);
    }
}
