using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    [SerializeField] private float _speedBackground;
    [SerializeField] private MeshRenderer _meshRenderer;

    private Vector2 _meshOffset;
    
    private void Start()
    {
        _meshOffset = _meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        _meshRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
    }
    
    private void Update()
    {
        float x = Mathf.Repeat(Time.time * _speedBackground, 1);
        Vector2 offset = new Vector2(x, _meshOffset.y);

        _meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}
