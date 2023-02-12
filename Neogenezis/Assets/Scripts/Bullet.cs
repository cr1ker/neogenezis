using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ExplodingPrefab;
    
    private void OnCollisionEnter(Collision other)
    {
        ExplodingPrefab.transform.position = transform.position;
        Instantiate(ExplodingPrefab);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        ExplodingPrefab.transform.position = transform.position;
        Instantiate(ExplodingPrefab);
        Destroy(gameObject);
    }
}
