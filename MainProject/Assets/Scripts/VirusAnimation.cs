using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VirusAnimation : MonoBehaviour
{
    public Rigidbody VirusRigidbody;
    public float Speed;

    void Start()
    {
        Transform playerTransform = FindObjectOfType<Body>().transform;
        Vector3 toPlayer = (playerTransform.position - gameObject.transform.position).normalized;
        VirusRigidbody.velocity = toPlayer * Speed;
    }
    
    void Update()
    {
        gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f) * (Mathf.Sin(Time.time * 5f) * 0.1f + 1f); 
    }
}
