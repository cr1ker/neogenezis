using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemyTriggerDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Bullet>())
        {
            gameObject.GetComponent<EnemyHealth>().Health -= 1;
        }
    }
}
