using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateToEuler : MonoBehaviour
{
    public Vector3 LeftEuler;
    public Vector3 RightEuler;
    
    public float SpeedRotation;

    private Vector3 _targetEuler;

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), SpeedRotation * Time.deltaTime);
    }
    public void RotateToRight() => _targetEuler = RightEuler;

    public void RotateToLeft() => _targetEuler = LeftEuler;
}
