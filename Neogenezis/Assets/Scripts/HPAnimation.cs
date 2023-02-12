using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPAnimation : MonoBehaviour
{
    public Animator HealthBarAnimation;
    private float _time;

    void Update()
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
