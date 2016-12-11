using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitLookat : MonoBehaviour {

    [SerializeField]
    public bool follow = true;
    [SerializeField]
    public bool tracking = true;

    [SerializeField]
    GameObject fly;

    float distance;
    float time = 0.0f;

    [SerializeField]
    float factor = 0.5f;

	// Use this for initialization
	void Start () {
        distance = Vector3.Distance(fly.transform.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (follow)
        {
            float x = distance * Mathf.Cos(time * factor);
            float z = distance * Mathf.Sin(time * factor);
            Vector3 offset = new Vector3(x, 0, z);
            transform.position = fly.transform.position + offset;
        }

        if (tracking)
            transform.rotation = Quaternion.LookRotation(fly.transform.position - transform.position);
    }
}
