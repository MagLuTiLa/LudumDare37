using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    [SerializeField]
    GameObject birdPrefab;
    GameObject deathcamObject;

    void Start()
    {
        deathcamObject = GameObject.Find("DeathCam");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Fly")
            return;
        deathcamObject.GetComponent<Camera>().enabled = true;
        deathcamObject.GetComponent<OrbitLookat>().follow = false;

        Invoke("flyby", 5.0f);
    }

    void flyby()
    {
        GameObject bird = Instantiate(birdPrefab);
        Vector3 birdSpawnPos = deathcamObject.transform.position + deathcamObject.transform.right * 50.0f;
        birdSpawnPos.y += 5.0f;

        bird.transform.position = birdSpawnPos;
    }
}
