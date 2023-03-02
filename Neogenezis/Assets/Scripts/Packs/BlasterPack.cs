using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterPack : MonoBehaviour
{
    private string _blaster = "Blaster";

    public void OnTriggerEnter(Collider other)
    {
        CurrentGun currentGun = other.attachedRigidbody.GetComponent<CurrentGun>();
        if (currentGun)
        {
            currentGun.GetGunByName(_blaster);
            Destroy(gameObject);
        }
    }
}
