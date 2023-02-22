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
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float _distanceForShoot;
    private GameObject _currentEnemy;
    private float _closestEnemyDistance;

    private void Start()
    {
        DirectGunTo();
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
        Vector3 toBody = Crosshair.position - Body.position;
        RotatePlayer(toBody);
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
            if (toAim != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(toAim);
                _gun.rotation = Quaternion.LookRotation(toAim);
            }
        }
    }

    private void RotatePlayer(Vector3 body)
    {
        Body.rotation = body.x < 0 ?
            Quaternion.Lerp(Body.rotation,LeftQuaternion,Time.deltaTime * SpeedRotation) 
            : 
            Quaternion.Lerp(Body.rotation,RightQuaternion,Time.deltaTime * SpeedRotation);
    }
}
  