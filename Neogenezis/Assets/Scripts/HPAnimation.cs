using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPAnimation : MonoBehaviour
{
    [SerializeField] private Animator HealthBarAnimation;
    private float _time;

    private void LateUpdate()
    {
        _time += Time.deltaTime;
        if (_time >= 10)
        {
            HealthBarAnimation.SetBool("IsActive", true);
            Invoke(nameof(SetFalse), 10f);
        }else
        {
            HealthBarAnimation.SetBool("IsActive", false);
        }
    }

    private void SetFalse()
    {
        HealthBarAnimation.SetBool("IsActive", false);
        _time = 0;
    } 
}
