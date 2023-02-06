using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{
    public int Damage;
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            other.gameObject.GetComponent<PlayerHealth>().OnHit(Damage);
        }
    }
}
