using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class UFO : MonoBehaviour, IUFOContoller
{
    [SerializeField] private Animator RayAnimator;
    [SerializeField] private MeshRenderer _player;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private GameObject _blockMoveButton; //in start scene, player cannot move, its just for visual
    [SerializeField] private GameObject _blockJumpButton;
    
    [SerializeField] private UnityEvent _eventOnStartUfoAction;
    [SerializeField] private UnityEvent _eventOnFinishUfoAction;
    
    private void Start()
    {
        _joystick.enabled = false;
        _eventOnStartUfoAction.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _eventOnFinishUfoAction.Invoke();
        }
    }
    
    public void SpawnAction()
    {
        SetAnimationBool(true);
        StartCoroutine(SetPlayerActive());
        SetAnimationBool(false);
    }

    public void FinishAction()
    {
        SetAnimationBool(true);
        StartCoroutine(SetPlayerInactive());
        SetAnimationBool(false);
    }

    private IEnumerator SetPlayerActive()
    {
        yield return new WaitForSeconds(3);
        _player.enabled = true;
        yield return new WaitForSeconds(2);
        SetMovingButtonsBool(false);
        _joystick.enabled = true;
    }

    private IEnumerator SetPlayerInactive()
    {
        yield return new WaitForSeconds(3);
        _player.enabled = false;
        yield return new WaitForSeconds(2);
        SetMovingButtonsBool(true);
        _joystick.enabled = false;
    }

    private void SetAnimationBool(bool isActive) => RayAnimator.SetBool("RayActive", isActive);

    private void SetMovingButtonsBool(bool isActive)
    {
        _blockJumpButton.SetActive(isActive);
        _blockMoveButton.SetActive(isActive);
    }
}
