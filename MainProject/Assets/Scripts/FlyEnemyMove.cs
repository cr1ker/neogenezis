using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMove : MonoBehaviour
{
    public Rigidbody Enemy;
    public Transform _playerTransform;
    public float Speed;
    public float TimeToReachPlayer;

    void Update()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = Enemy.mass * (toPlayer * Speed - Enemy.velocity) / TimeToReachPlayer;
        Enemy.AddForce(force); 
    }
}
