using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBox : MonoBehaviour
{
    public float HeightOfMovingLift;

    void Update()
    {
        transform.localPosition = new Vector3(0,Mathf.Sin(Time.time * 0.7f) * HeightOfMovingLift + HeightOfMovingLift, 0);
    }
}
