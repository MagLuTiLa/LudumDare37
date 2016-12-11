using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEater : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        Restart();
    }

    void Restart()
    {
        anim.SetBool("Closed", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Fly")
            return;


        Animator anim = transform.parent.GetComponent<Animator>();
        anim.SetBool("Closed", true);
        other.gameObject.GetComponent<Hazard>().Eaten(other);
    }
}
