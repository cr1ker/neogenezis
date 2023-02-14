using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _enemy;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToReachPlayer;

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _enemy.mass * (toPlayer * _speed - _enemy.velocity) / _timeToReachPlayer;
        _enemy.AddForce(force); 
    }
}
