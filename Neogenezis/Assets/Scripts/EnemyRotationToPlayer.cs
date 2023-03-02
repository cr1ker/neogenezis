using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotationToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;
    private const float RotationSpeed = 3.5f; // why 3.5f? because according to the tests 3.5f an ideal speed for rotating
    
    private Transform _playerTransform;
    
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
    {
        if (_playerTransform.position.x < gameObject.transform.position.x)
        {
            //turn on left
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(_leftEuler), Time.deltaTime * RotationSpeed);
        }
        else
        {
            //turn on right
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(_rightEuler), Time.deltaTime * RotationSpeed);
        }
    }
}
