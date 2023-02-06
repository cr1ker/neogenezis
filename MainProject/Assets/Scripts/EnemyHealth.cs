using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health;
    public UnityEvent GetDamage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            Health -= 1;
            GetDamage.Invoke();
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        
    }
}
