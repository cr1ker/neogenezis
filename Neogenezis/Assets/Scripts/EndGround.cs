using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGround : BasicDamageBlock
{
    public void OnCollisionEnter(Collision other)
    {
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
        if (player)
        {
            ApplyDamage();
        }
    }
    protected override void ApplyDamage()
    {
        base.ApplyDamage();
    }
}
