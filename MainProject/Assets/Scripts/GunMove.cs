using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    public Transform CrosshairPosition;
    

    void Update()
    {
        Vector3 relativePositon = CrosshairPosition.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePositon);
        transform.rotation = rotation;
    }
}
