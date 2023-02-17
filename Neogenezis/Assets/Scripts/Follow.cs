using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float Speed;
    
    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, Target.position, Time.deltaTime * Speed);
    }
}
