using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lava : BasicDamageBlock
{
    [SerializeField] private float _force;

    public void OnTriggerStay(Collider other)
    {
        PlayerHealth player = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (player)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * _force,ForceMode.Acceleration);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.attachedRigidbody.GetComponent<PlayerHealth>();
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
