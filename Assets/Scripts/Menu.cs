using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Image background;

    void Start()
    {
        background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    public void ClickedOnStart()
    {
        Application.LoadLevel("The Room");
    }
}