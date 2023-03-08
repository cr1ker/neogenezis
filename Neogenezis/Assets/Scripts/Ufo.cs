using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class UFO : MonoBehaviour, IUFOContoller
{
    [SerializeField] protected Animator UfoAnimator;
    [SerializeField] protected MeshRenderer _player;
    [SerializeField] protected Joystick _joystick;
    [SerializeField] protected GameObject _blockMoveButton; //in start scene, player cannot move, its just for visual
    [SerializeField] protected GameObject _blockJumpButton;

    private void Start()
    {
        _joystick.enabled = false;
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
        
    }

    private IEnumerator SetPlayerActive()
    {
        yield return new WaitForSeconds(3);
        _player.enabled = true;
        yield return new WaitForSeconds(2);
        SetButtonsBool(false);
        _joystick.enabled = true;
    }

    private IEnumerator SetPlayerInactive()
    {
        SetButtonsBool(true);
        _joystick.enabled = false;
        yield return new WaitForSeconds(2);
        _player.enabled = false;
        yield return new WaitForSeconds(5);
        PassLevel();
    }

    private void PassLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("UnlockedLevels"))
        {
            PlayerPrefs.SetInt("UnlockedLevels", currentLevel + 1);
        }
    }
    
    private void SetAnimationBool(bool isActive) => UfoAnimator.SetBool("RayActive", isActive);
    private void SetButtonsBool(bool isActive)
    {
        _blockJumpButton.SetActive(isActive);
        _blockMoveButton.SetActive(isActive);
    }
}
