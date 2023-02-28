using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private Joystick _joystick;
    private Transform _body;
    [SerializeField] private Quaternion _leftQuaternion;
    [SerializeField] private Quaternion _rightQuaternion;

    private bool _grounded;
    private Rigidbody _playerRigidbody;
    private float _airSpeed;
    private const float SpeedRotation = 5;

    private void Awake()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody>();
        _body = FindObjectOfType<Body>().transform;
    }

    private void FixedUpdate()
    {
        _airSpeed = 1;
        if (_grounded is false)
        {
            _airSpeed = 0.1f; //while you fly, you dont have any additional force
        }
        _playerRigidbody.AddForce(_joystick.Horizontal * _playerSpeed * _airSpeed,0,0, ForceMode.VelocityChange);
        _playerRigidbody.AddForce(-_playerRigidbody.velocity.x * _friction * _airSpeed,0, 0, ForceMode.VelocityChange);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded is true)
        {
            _playerRigidbody.AddForce(0,_jumpSpeed,0, ForceMode.VelocityChange);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
    
    public void OnCollisionStay(Collision collision)
    {
        float Angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (Angle <= 48)
        {
            _grounded = true;
        }
    }

    public void Jump()
    {
        if (_grounded is true)
        {
            _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x,_jumpSpeed, 0f);
        }
    }

    private void RotatePlayerToDirection(float joystickPosition)
    {
        _body.rotation = joystickPosition < 0 ?
            Quaternion.Lerp(_body.rotation,_leftQuaternion,Time.deltaTime * SpeedRotation) 
            : 
            Quaternion.Lerp(_body.rotation,_rightQuaternion,Time.deltaTime * SpeedRotation);
    }
}
