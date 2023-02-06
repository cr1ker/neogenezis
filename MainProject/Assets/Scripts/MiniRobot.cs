using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRobot : MonoBehaviour
{
    private Transform _playerTransform;
    public Animator RobotAnimation;
    
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(_playerTransform.position,gameObject.transform.position);
        if (distance < 10)
        {
            RobotAnimation.SetBool("Distance", true);
        }
        else
        {
            RobotAnimation.SetBool("Distance", false);
        }
    }
}
