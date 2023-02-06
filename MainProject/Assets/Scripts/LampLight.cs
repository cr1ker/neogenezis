using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    public Light LightOfLamp;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > 3)
        {
            LightOfLamp.intensity = 0;
            _time = 0;
        }
        else if(_time > 1.5f)
        {
            LightOfLamp.intensity = 5;
        }
    }
}
