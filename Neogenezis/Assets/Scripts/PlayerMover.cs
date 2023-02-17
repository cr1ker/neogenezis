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
    
    private bool _grounded;
    private Rigidbody _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody>();
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

    private void FixedUpdate()
    {
        float AirSpeed = 1;
        if (_grounded is false)
        {
            AirSpeed = 0.1f; //while you fly, you dont have any additional force
        }
        _playerRigidbody.AddForce(_joystick.Horizontal * _playerSpeed * AirSpeed,0,0, ForceMode.VelocityChange);
        _playerRigidbody.AddForce(-_playerRigidbody.velocity.x * _friction * AirSpeed,0, 0, ForceMode.VelocityChange);
    }
}
