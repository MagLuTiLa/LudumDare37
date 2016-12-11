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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Fly")
            return;


        Animator anim = transform.parent.GetComponent<Animator>();
        anim.SetTrigger("Close");
        other.gameObject.GetComponent<Hazard>().PlantFood(GetComponent<Collider>());
    }
}
