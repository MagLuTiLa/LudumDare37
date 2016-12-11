using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    [SerializeField]
    GameObject restartPrefab;
    Collider killzone;
    public void PlantFood(Collider killzone)
    {
        this.killzone = killzone;
        StopMovement();
        transform.position = killzone.transform.position;
        GameObject.Find("DeathCam").GetComponent<Camera>().enabled = true;
        Debug.Log("PlantFood");
        Invoke("SpawnRestart", 5.0f);
    }

    void Update()
    {
        if (killzone != null)
            if (Input.GetKeyDown(KeyCode.K))
            {
                transform.position = killzone.transform.position;
            }
    }
    public void BirdFood()
    {
        StopMovement();
    }

    private void StopMovement()
    {
        GetComponent<FlyController>().enabled = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = new Vector3();
    }

    void SpawnRestart()
    {
        GameObject restartText = Instantiate(restartPrefab, GameObject.Find("Canvas").transform);
        restartText.transform.localPosition = new Vector3(0, -200, 0);

    }
}
