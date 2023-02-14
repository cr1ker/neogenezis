using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (player)
        {
            player.GetHealthPack();
            Destroy(gameObject);
        }
    }
}
