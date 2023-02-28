using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBox : BaseMovingObjects
{
    [SerializeField] private float _heightOfMovingLift;

    private void Update()
    {
        MoveObject(_heightOfMovingLift);
    }
}
