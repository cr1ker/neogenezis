using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [Header("Joystick")]
    [SerializeField] private Joystick _joystick;
    [Header("Player Rotation")]
    [SerializeField] private Quaternion _leftQuaternion;
    [SerializeField] private Quaternion _rightQuaternion;
    [Header("Player Sounds")] 
    [SerializeField] private AudioSource _jumpSound;

    private Animator _playerAnimator;
    private Transform _body;
    private bool _grounded;
    private bool _isMovingControllerActive;
    private Rigidbody _playerRigidbody;
    private float _airSpeed;
    private const float SpeedRotation = 5;

    private string _isPlayerMove = "IsPlayerMove";
    private string _isPlayerJump = "IsPlayerJump";

    private void Awake()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody>();
        _body = FindObjectOfType<Body>().transform;
        _playerAnimator = _body.GetComponent<Animator>();
        _isMovingControllerActive = true;
    }

    private void FixedUpdate()
    {
        _airSpeed = 1;
        if (_grounded is false)
        {
            _airSpeed = 0.1f; //while you fly, you dont have any additional force
        }
        if (_isMovingControllerActive)
        {
            _playerRigidbody.AddForce(_joystick.Horizontal * _playerSpeed * _airSpeed,0,0, ForceMode.VelocityChange);
            _playerRigidbody.AddForce(-_playerRigidbody.velocity.x * _friction * _airSpeed,0, 0, ForceMode.VelocityChange);
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded is true)
        {
            _playerRigidbody.AddForce(0,_jumpSpeed,0, ForceMode.VelocityChange);
            StartCoroutine(SetAnimationBool(_isPlayerJump, true, 0));
            StartCoroutine(SetAnimationBool(_isPlayerJump, false, 1));
        }
    }

    private void LateUpdate()
    {
        if (_joystick.Horizontal != 0 && _grounded is true)
        {
            _playerAnimator.SetBool(_isPlayerMove, true);
            _playerAnimator.speed = Mathf.Abs(_joystick.Horizontal) >= 0.5 ? Mathf.Abs(_joystick.Horizontal) : 0.5f;
        }
        else
        {
            _playerAnimator.SetBool(_isPlayerMove, false);
            _playerAnimator.speed = 1;
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
        if (_grounded is true && _isMovingControllerActive)
        {
            _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x,_jumpSpeed, 0f);
            _jumpSound.pitch = Random.Range(2.5f, 3f);
            _jumpSound.Play();
            StartCoroutine(SetAnimationBool(_isPlayerJump, true, 0));
            StartCoroutine(SetAnimationBool(_isPlayerJump, false, 1));
        }
    }

    private void RotatePlayerToDirection(float joystickPosition)
    {
        _body.rotation = joystickPosition < 0 ?
            Quaternion.Lerp(_body.rotation,_leftQuaternion,Time.deltaTime * SpeedRotation) 
            : 
            Quaternion.Lerp(_body.rotation,_rightQuaternion,Time.deltaTime * SpeedRotation);
    }

    private IEnumerator SetAnimationBool(string parameter, bool status, float timeBeforeCall) //for invoke with time
    {
        yield return new WaitForSeconds(timeBeforeCall);
        _playerAnimator.SetBool(parameter, status);
    }

    public void ChangeValueOfMovingController(bool status)
    {
        _playerRigidbody.velocity = Vector3.zero;
        _isMovingControllerActive = status;
    }
}
