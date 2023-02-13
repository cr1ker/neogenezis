using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovingObjects : MonoBehaviour
{
    protected void MoveObject(float heightOfMoving)
    {
        transform.localPosition = new Vector3(0,Mathf.Sin(Time.time * 0.7f) * heightOfMoving + heightOfMoving, 0);
    }
}
