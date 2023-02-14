using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    [SerializeField]private int _enemyDamage;
    private bool _invulnerable;
    
    public void OnCollisionEnter(Collision other)
    {
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
        if (player)
        {
            if (_invulnerable == false)
            {
                player.OnHit(_enemyDamage); //if enemy have come close, we use OnHit for damage
                _invulnerable = true;
                Invoke(nameof(SetInvulnerable),1f);
            }
        }
    }

    public void OnCollisionStay(Collision other)
    {
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
        if (player)
        {
            if (_invulnerable == false)
            {
                player.OnHit(_enemyDamage); //if enemy have come close, we use OnHit for damage
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
