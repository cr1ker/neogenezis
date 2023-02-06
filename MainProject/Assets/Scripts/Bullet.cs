using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ExplodingPrefab;
    
    void OnCollisionEnter(Collision other)
    {
        ExplodingPrefab.transform.position = transform.position;
        Instantiate(ExplodingPrefab);
        Destroy(gameObject);
    }
}
