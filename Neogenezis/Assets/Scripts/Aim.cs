using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform Crosshair;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform Body;
    
    [SerializeField] private Quaternion LeftQuaternion;
    [SerializeField] private Quaternion RightQuaternion;
    private const float SpeedRotation = 5;
    
    private void LateUpdate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction);
        
        Plane plane = new Plane(-Vector3.forward,Vector3.zero);

        plane.Raycast(ray, out float distance);
        Vector3 point = ray.GetPoint(distance);

        Crosshair.position = point;

        Vector3 toAim = Crosshair.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        Vector3 toBody = Crosshair.position - Body.position;
        RotatePlayer(toBody);
    }

    private void RotatePlayer(Vector3 body)
    {
        Body.rotation = body.x < 0 ?
            Quaternion.Lerp(Body.rotation,LeftQuaternion,Time.deltaTime * SpeedRotation) 
            : 
            Quaternion.Lerp(Body.rotation,RightQuaternion,Time.deltaTime * SpeedRotation);
    }
}
  