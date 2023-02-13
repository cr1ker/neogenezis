using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusAnimation : MonoBehaviour
{
    [SerializeField]private float SpeedRotation;
    
    private void Update()
    {
        transform.Rotate(SpeedRotation * Time.deltaTime,0,0);
    }
}
