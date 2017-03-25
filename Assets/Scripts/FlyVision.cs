using System.Collections;
using UnityEngine;

public class FlyVision : MonoBehaviour {

    private Material material;

    // Creates a private material used to the effect
    void Awake()
    {
        //material = new Material(Shader.Find("Hidden/FlyVision"));
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Graphics.Blit(source, destination, material);
    }
	
}
