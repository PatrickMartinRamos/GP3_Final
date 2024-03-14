using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBG : MonoBehaviour
{
    public float speed;

    public Renderer cellarBGRenderer;

    void Update()
    {
        cellarBGRenderer.material.mainTextureOffset += new Vector2(speed*Time.deltaTime,0);
    }
}
