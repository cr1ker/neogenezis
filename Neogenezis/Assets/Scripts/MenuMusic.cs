using System.Collections;
using System.Collections.Generic;
using Michsky.UI.Shift;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        bool isMusicOn = FindObjectOfType<SwitchManager>().isOn;
        if (isMusicOn)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
