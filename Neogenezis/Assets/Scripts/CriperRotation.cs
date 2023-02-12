using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriperRotation : MonoBehaviour
{
    public Vector3 LeftEuler;
    public Vector3 RightEuler;
    private const float RotationSpeed = 3.5f; // why 3.5f? because according to the tests 3.5f an ideal speed for rotating
    
    private Transform _playerTransform;
    
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMoving>().transform;
    }

    void Update()
    {
        if (_playerTransform.position.x-2.5f < gameObject.transform.position.x) //2.5f because player x is bigger, when you come close
        {
            //turn on left
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(LeftEuler), Time.deltaTime * RotationSpeed);
        }
        else
        {
            //turn on right
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(RightEuler), Time.deltaTime * RotationSpeed);
        }
    }
}
