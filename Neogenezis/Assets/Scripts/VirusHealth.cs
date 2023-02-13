using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusHealth : EnemyHealth
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
