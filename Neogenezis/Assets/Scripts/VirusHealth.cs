using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusHealth : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
