using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject swatSelector;
    public Image background;

    void Start()
    {
        background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    private void Update()
    {
        swatSelector.transform.position = Input.mousePosition + new Vector3(500, 0);

        if (Input.GetMouseButtonDown(0))
        {
            swatSelector.SendMessage("Swat");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("The Room");
    }

    public void Quit()
    {
        Application.Quit();
    }
}