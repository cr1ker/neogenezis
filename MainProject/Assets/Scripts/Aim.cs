using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform Crosshair;
    public Camera PlayerCamera;
    public Transform Body;
    
    public Quaternion LeftQuaternion;
    public Quaternion RightQuaternion;
    private const float _speedRotation = 5;

    void LateUpdate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);
        
        Plane plane = new Plane(-Vector3.forward,Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        Crosshair.position = point;

        Vector3 toAim = Crosshair.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        Vector3 toBody = Crosshair.position - Body.position;
        LeftQuaternion = Quaternion.Euler(270,155,0);
        RightQuaternion = Quaternion.Euler(270, 25, 0);
        Body.rotation = toBody.x < 0 ?
            Quaternion.Lerp(Body.rotation,LeftQuaternion,Time.deltaTime * _speedRotation) 
            : 
            Quaternion.Lerp(Body.rotation,RightQuaternion,Time.deltaTime * _speedRotation);
    }
}
  