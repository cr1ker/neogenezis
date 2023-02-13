using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IGunDamage
{
    public int Health;
    public UnityEvent GetDamage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            Health -= GunDamage();
            GetDamage.Invoke();
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public int GunDamage()
    {
        return FindObjectOfType<Gun>().GetGunDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Bullet>())
        {
            Health -= GunDamage();
            GetDamage.Invoke();
            if (Health <= 0)
            {
                Destroy(gameObject); 
            }
        }
    }
}
