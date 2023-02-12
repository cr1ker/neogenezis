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
    public Transform RightPoint;
    public Transform LeftPoint;

    public Direction CurrentDirection;
    
    public float Speed;
    public float RotationSpeed;
    
    private RotateToEuler _rotateToEuler;

    private bool _isStopped;
    
    public UnityEvent EventOnRightTarget;
    public UnityEvent EventOnLeftTarget;
    
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
                EventOnRightTarget.Invoke();
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
                EventOnLeftTarget.Invoke();
                Invoke(nameof(ContinueMove),RotationSpeed);
            }
        }
    }

    private void ContinueMove() => _isStopped = false;
}
