using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public void SetPlayerDieAction()
    {
        IEnumerator restartAction = FindObjectOfType<LevelMessage>().SetRestartAction();
        StartCoroutine(restartAction);
    }
}
