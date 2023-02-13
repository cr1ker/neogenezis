using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            FindObjectOfType<BulletCreator>().GetBulletPack();
            Destroy(gameObject);
        }
    }
}
