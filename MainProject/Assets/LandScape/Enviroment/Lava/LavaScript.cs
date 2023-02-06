using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public Renderer LavaMaterial;

    void Start()
    {
        LavaMaterial = GetComponent<Renderer>();
    }
    
    void Update()
    {
        float scaleX = Mathf.Cos(Time.time * 1f) * 0.3f + 3f;
        float scaleY = Mathf.Cos(Time.time * 1f) * 0.1f + 3f;
        LavaMaterial.material.SetTextureScale("_MainTex", new Vector2(scaleX, scaleY));
    }
}
