using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criper : MonoBehaviour
{
    public Transform _playerTransfom;
    public Transform _criperTransform;
    
    public Animator CriperAnimator;

    void Update()
    {
        float distance = Vector3.Distance(_playerTransfom.position, _criperTransform.position);
        Vector3 toPlayer = _playerTransfom.position - _criperTransform.position;
        if (distance <= 10)
        {
            CriperAnimator.SetBool("Attack",true);
        }
        else
        {
            CriperAnimator.SetBool("Attack",false);
        }
    }
}
