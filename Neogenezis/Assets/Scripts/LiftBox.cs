using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBox : BaseMovingObjects
{
    public float HeightOfMovingLift;

    private void Update()
    {
        MoveObject(HeightOfMovingLift);
    }
}
