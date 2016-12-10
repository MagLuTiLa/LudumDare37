using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OpenWindowRandomizer : MonoBehaviour
{

    public bool ShouldFindWindowsOnRuntime; //uncheck if we manually drag the windows into the list.
    public string WindowTag = "Window";

    public GameObject[] Windows;
    
	void Start ()
	{
        //find windows if we want.
	    if (ShouldFindWindowsOnRuntime)
	         Windows = FindWindows();

        //open a random window.
        OpenRandomWindow();
	}

    /// <summary>
    /// Find all windows in the scene
    /// </summary>
    /// <returns>all windows</returns>
    private GameObject[] FindWindows()
    {
        return GameObject.FindGameObjectsWithTag(WindowTag);
    }

    /// <summary>
    /// opens a random window
    /// </summary>
    private void OpenRandomWindow()
    {
        int choice = Random.Range(0, Windows.Length);
        OpenWindow(Windows[choice]);
    }

    /// <summary>
    /// Opens the window.
    /// </summary>
    /// <param name="window">the window</param>
    private void OpenWindow(GameObject window)
    {
        Collider windowCollider = window.GetComponent<Collider>();  

        if(windowCollider == null)
            throw new Exception("No collider attached to window");

        windowCollider.enabled = false;
    }
}
