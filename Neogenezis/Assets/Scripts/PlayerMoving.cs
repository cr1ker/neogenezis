using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed;
    [SerializeField] private Rigidbody PlayerRigidbody;
    [SerializeField] private float JumpSpeed;
    [SerializeField] private float Friction;
    private bool _grounded;

    [SerializeField] private Transform PlayerScale; //for sit down
    [SerializeField] private float SitDownSpeed;
    
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector3 sitScale = new Vector3(1f, 0.8f, 1f);
            PlayerScale.localScale = Vector3.Lerp(PlayerScale.localScale, sitScale, Time.deltaTime * SitDownSpeed);
        }
        else
        {
            PlayerScale.localScale = Vector3.Lerp(PlayerScale.localScale, Vector3.one, Time.deltaTime * SitDownSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _grounded is true)
        {
            PlayerRigidbody.AddForce(0,JumpSpeed,0,ForceMode.VelocityChange);
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

    void FixedUpdate()
    {
        float AirSpeed = 1;
        if (_grounded is false)
        {
            AirSpeed = 0.1f; //while you fly, you dont have any additional force
        }
        PlayerRigidbody.AddForce(Input.GetAxis("Horizontal") * PlayerSpeed * AirSpeed,0,0, ForceMode.VelocityChange);
        PlayerRigidbody.AddForce(-PlayerRigidbody.velocity.x * Friction * AirSpeed,0, 0, ForceMode.VelocityChange);
    }
}
