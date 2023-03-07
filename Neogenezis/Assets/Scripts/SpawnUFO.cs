using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUFO : UFO
{
    private void Start()
    {
        _joystick.enabled = false;
        SpawnAction();
    }
}
