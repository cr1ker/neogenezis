using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform Crosshair;
    [SerializeField] private Transform Body;

    [SerializeField] private Quaternion LeftQuaternion;
    [SerializeField] private Quaternion RightQuaternion;
    private const float SpeedRotation = 5;
    [SerializeField] private Transform _gun;
    [SerializeField] protected Joystick _joystick;
    private float _offset;

    private void Start()
    {
        _offset = 0;
        DirectGunTo();
    }
    
    /*private void LateUpdate()
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
    }*/

    private void LateUpdate()
    {
        if (IsJoysticActive())
        {
            _offset = -90;
            DirectGunTo();
        }
        Vector3 toBody = Crosshair.position - Body.position;
        RotatePlayer(toBody);
    }

    private void DirectGunTo()
    {
        float rotateX = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(rotateX + _offset,0f,0f);
        Vector3 toAim = Crosshair.position - transform.position;
        _gun.rotation = Quaternion.LookRotation(toAim);
    }

    private bool IsJoysticActive()
    {
        bool _isStickMoving = _joystick.Vertical > 0 || _joystick.Vertical < 0 || _joystick.Horizontal > 0 ||
                              _joystick.Horizontal < 0;
        return _isStickMoving;
    }
    
    private void RotatePlayer(Vector3 body)
    {
        Body.rotation = body.x < 0 ?
            Quaternion.Lerp(Body.rotation,LeftQuaternion,Time.deltaTime * SpeedRotation) 
            : 
            Quaternion.Lerp(Body.rotation,RightQuaternion,Time.deltaTime * SpeedRotation);
    }
}
  