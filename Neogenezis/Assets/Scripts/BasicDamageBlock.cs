using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicDamageBlock : MonoBehaviour
{
    [SerializeField] private int _blockDamage;

    protected virtual void ApplyDamage()
    {
        FindObjectOfType<PlayerHealth>().OnHit(_blockDamage);
    }
}
