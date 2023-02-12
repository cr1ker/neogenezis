using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == nameof(Bullet))
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
