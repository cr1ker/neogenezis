using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMove : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        Vector3 reletivePosition = Target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(reletivePosition);
    }
}
