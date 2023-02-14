using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRobot : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private Animator RobotAnimation;
    
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
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
