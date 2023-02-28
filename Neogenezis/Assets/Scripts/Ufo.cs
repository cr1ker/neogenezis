using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFO : MonoBehaviour, IUFOContoller
{
    [SerializeField] private Animator RayAnimator;
    [SerializeField] private MeshRenderer _player;
    
    private void Start()
    {
        SpawnAction();
    }

    public void SpawnAction()
    {
        SetAnimationBool(true);
        StartCoroutine(SetPlayerActive());
        SetAnimationBool(false);
    }

    public void FinishAction()
    {
        
    }

    private IEnumerator SetPlayerActive()
    {
        yield return new WaitForSeconds(3);
        _player.enabled = true;
    }

    private void SetAnimationBool(bool isActive) => RayAnimator.SetBool("RayActive", isActive);
}
