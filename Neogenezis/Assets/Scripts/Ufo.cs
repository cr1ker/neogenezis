using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    public Animator RayAnimator;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            RayAnimator.SetBool("RayActive",true);
        }
        else
        {
            RayAnimator.SetBool("RayActive", false);
        }
    }
}
