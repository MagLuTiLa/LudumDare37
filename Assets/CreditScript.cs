using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public GameObject returnText;

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().time = 8.0f;
        Invoke("ShowBackToMenu", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("Menu");
    }

    void ShowBackToMenu()
    {
        returnText.SetActive(true);
    }
}
