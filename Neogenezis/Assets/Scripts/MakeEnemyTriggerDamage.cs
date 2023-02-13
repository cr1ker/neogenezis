using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemyTriggerDamage : EnemyHealth
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Bullet>())
        {
            Health -= 1;
        }
    }
}
