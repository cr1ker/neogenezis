using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishUFO : UFO
{
    [SerializeField] private GameObject _blockShootButton;
    public void FinishLevelAnimation()
    {
        FinishAction();
        GameObject currentGun = FindObjectOfType<Gun>().gameObject;
        currentGun.SetActive(false);
        _blockShootButton.SetActive(true);
    }
}
