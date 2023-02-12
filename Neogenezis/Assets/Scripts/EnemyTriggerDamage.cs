using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTriggerDamage : MonoBehaviour
{
    public int TriigerDamage;
    private bool _invulnerable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            if (_invulnerable == false)
            {
                other.attachedRigidbody.GetComponent<PlayerHealth>().OnHit(TriigerDamage);
                _invulnerable = true;
                Invoke(nameof(_setInvulnerable),1f);
            }
        }
    }

    private bool _setInvulnerable() => _invulnerable = false;
}
