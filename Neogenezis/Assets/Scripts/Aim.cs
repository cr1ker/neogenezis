using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform Crosshair;
    [SerializeField] private Transform Body;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Quaternion _leftQuaternion;
    [SerializeField] private Quaternion _rightQuaternion;
    private const float SpeedRotation = 5;
    [SerializeField] private Transform _gun;
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float _distanceForShoot;
    private GameObject _currentEnemy;
    private bool _isGunDirect;
    private float _closestEnemyDistance;
    private const short LeftDirectCrosshairPosition = -5;
    private const short RightDirectCrosshairPosition = 5;
    private Vector3 _defaultCrosshairPosition;

    private void Start()
    {
        _enemies = FindObjectOfType<EnemyIsActive>().GetEnemies();
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
        DirectGunTo();
        if (_isGunDirect)
        {
            Vector3 toBody = Crosshair.position - Body.position;
            RotatePlayer(toBody);
        }
        else
        {
            RotatePlayer(_joystick.Horizontal);
        }
    }

    private void DirectGunTo()
    {
        _closestEnemyDistance = _distanceForShoot;
        foreach (var enemy in _enemies)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(enemy.transform.position, Body.position);
                if (distance <= _closestEnemyDistance)
                {
                    _closestEnemyDistance = distance;
                    _currentEnemy = enemy;
                }
            }
        }
        if (_currentEnemy != null)
        {
            Crosshair.position = _currentEnemy.transform.position;
            Vector3 toAim = Crosshair.position - transform.position;
            RotateGunTo(toAim);
            _isGunDirect = true;
        }
        else
        {
            _isGunDirect = false;
        }
    }

    private void RotateGunTo(Vector3 toPosition)
    {
        if (toPosition != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(toPosition);
            _gun.rotation = Quaternion.LookRotation(toPosition);
        }
    }

    private void RotatePlayer(Vector3 body)
    {
        Body.rotation = body.x < 0 ?
            Quaternion.Lerp(Body.rotation,_leftQuaternion,Time.deltaTime * SpeedRotation) 
            : 
            Quaternion.Lerp(Body.rotation,_rightQuaternion,Time.deltaTime * SpeedRotation);
    }
    
    private void RotatePlayer(float joystickPosition)
    {
        if (joystickPosition < 0)
        {
            Body.rotation = Quaternion.Lerp(Body.rotation, _leftQuaternion, Time.deltaTime * SpeedRotation);
            _defaultCrosshairPosition = new Vector3(Body.position.x + LeftDirectCrosshairPosition, Body.position.y, 0f);
            Crosshair.position = _defaultCrosshairPosition;
        }
        else if(joystickPosition > 0)
        {
            Body.rotation = Quaternion.Lerp(Body.rotation,_rightQuaternion,Time.deltaTime * SpeedRotation);
            _defaultCrosshairPosition = new Vector3(Body.position.x + RightDirectCrosshairPosition, Body.position.y, 0f);
            Crosshair.position = _defaultCrosshairPosition;
        }
        else
        {
            Crosshair.position = _defaultCrosshairPosition;
        }
        Vector3 toAim = Crosshair.position - transform.position;
        RotateGunTo(toAim);
    }
}
  