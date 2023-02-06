using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusAnimation : MonoBehaviour
{
    public float SpeedRotation;
    
    void Update()
    {
        transform.Rotate(SpeedRotation * Time.deltaTime,0,0);
    }
}
