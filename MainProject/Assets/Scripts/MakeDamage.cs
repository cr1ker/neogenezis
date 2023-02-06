using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    public int EnemyDamage;
    private bool _invulnerable;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            if (_invulnerable == false)
            {
                other.gameObject.GetComponent<PlayerHealth>().OnHit(EnemyDamage); //if enemy have come close, we use OnHit for damage
                _invulnerable = true;
                Invoke(nameof(SetInvulnerable),1f);
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            if (_invulnerable == false)
            {
                other.gameObject.GetComponent<PlayerHealth>().OnHit(EnemyDamage); //if enemy have come close, we use OnHit for damage
                _invulnerable = true;
                Invoke(nameof(SetInvulnerable),1f);
            }
        }
    }

    private void SetInvulnerable()
    {
        _invulnerable = false;
    }
}
