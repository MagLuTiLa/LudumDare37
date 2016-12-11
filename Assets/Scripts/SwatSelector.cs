using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatSelector : MonoBehaviour
{
    public GameObject swatter;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Swat()
    {
        StartCoroutine(PerformSwat());
    }

    IEnumerator PerformSwat()
    {
        float startAngle = swatter.transform.eulerAngles.y;
        float delta = 0;
        SoundManager.PlaySound("Swat");
        while (delta < 1)
        {
            delta += Time.deltaTime * 10;
            swatter.transform.eulerAngles = Vector3.Lerp(new Vector3(0, -95, 0), Vector3.zero, delta);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        while (delta > 0)
        {
            delta -= Time.deltaTime * 10;
            swatter.transform.eulerAngles = Vector3.Lerp(new Vector3(0, -95, 0), Vector3.zero, delta);
            yield return null;
        }

        yield return null;
    }
}
