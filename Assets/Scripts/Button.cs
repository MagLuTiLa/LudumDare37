using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public GameObject[] Obj = new GameObject[0];

    public bool ChangeColor;

    public Color On = new Color(0, 1, 0);
    public Color Off = new Color(1, 0, 0);
    public bool State = true;

    private Renderer _rend;

    // Use this for initialization
    void Start()
    {
        _rend = GetComponent<Renderer>();

        if (ChangeColor)
            _rend.material.color = (State ? On : Off);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            foreach(GameObject obj in Obj)
                obj.BroadcastMessage("Toggle");
            State = !State;
            if (ChangeColor)
                _rend.material.color = ( State ? On : Off);
        }
    }
}