using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPackAnimation : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    
    private void Update()
    {
        transform.Rotate(0f, 0f, _speedRotation * Time.deltaTime);
    }
}
