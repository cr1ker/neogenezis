using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemyTriggerDamage : EnemyHealth
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Bullet>())
        {
            Health -= 1;
        }
    }
}
