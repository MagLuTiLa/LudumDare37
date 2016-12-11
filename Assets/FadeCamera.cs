using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Fade { In, Out }

public class FadeCamera : MonoBehaviour
{
    [SerializeField]
    Texture2D fadeTexture;
    [SerializeField]
    float fadeSpeed = 0.1f;

    [SerializeField]
    int drawDepth = -1000;

    [SerializeField]
    public Fade state = Fade.In;

    private float alpha = 1.0f;


    void OnGUI()
    {
        float fadeDir = -1;
        if (state == Fade.In)
            fadeDir = 1;

        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        Color guiColor = GUI.color;
        guiColor.a = alpha;
        GUI.color = guiColor;
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
}
