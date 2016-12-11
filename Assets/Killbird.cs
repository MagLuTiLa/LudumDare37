using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbird : MonoBehaviour {

    GameObject target;
    GameObject cam;
	// Use this for initialization
	void Start ()
    {
        cam = GameObject.Find("DeathCam");
        target = GameObject.Find("Fly");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 50.0f * Time.deltaTime);
            

            if (target.transform.position.Equals(transform.position))
            {
                target.GetComponent<Hazard>().BirdFood();
                target.transform.SetParent(transform);
                target = null;
                cam.GetComponent<OrbitLookat>().tracking = false;
                cam.GetComponent<FadeCamera>().state = Fade.In;
            }
            else
                transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-cam.transform.right), 5.0f * Time.deltaTime);
            transform.position += transform.forward * 50.0f * Time.deltaTime;
        }
	}
}
