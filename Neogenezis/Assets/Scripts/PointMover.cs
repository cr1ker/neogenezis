using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Right,
    Left
}

public class PointMover : MonoBehaviour
{
    [SerializeField]private Transform RightPoint;
    [SerializeField]private Transform LeftPoint;

    private Direction CurrentDirection;
    
    [SerializeField]private float Speed;
    [SerializeField]private float RotationSpeed;
    
    private RotateToEuler _rotateToEuler;

    private bool _isStopped;
    
    [SerializeField]private UnityEvent _eventOnRightTarget;
    [SerializeField]private UnityEvent _eventOnLeftTarget;
    
    private void Start()
    {
        RightPoint.parent = null;
        LeftPoint.parent = null;
        _isStopped = false;
        _rotateToEuler = GetComponent<RotateToEuler>();
    }

    private void Update()
    {
        if (_isStopped is true)
        {
            return;
        }
        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x < LeftPoint.position.x)
            {
                _isStopped = true;
                CurrentDirection = Direction.Right;
                _eventOnRightTarget.Invoke();
                Invoke(nameof(ContinueMove),RotationSpeed);
            }
        }
        else
        {
            gameObject.transform.position += new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x > RightPoint.position.x)
            {
                _isStopped = true;
                CurrentDirection = Direction.Left;
                _eventOnLeftTarget.Invoke();
                Invoke(nameof(ContinueMove),RotationSpeed);
            }
        }
    }

    private void ContinueMove() => _isStopped = false;
}
