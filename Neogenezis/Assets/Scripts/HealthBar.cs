using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{  
    public RawImage[] healthPoints;
    public PlayerHealth Health;

    private void Start()
    {
        Health.Health = Health.MaxHealth; 
    }

    private void Update()
    {
        HealthFiller();
    }
    private void HealthFiller()
    {
        for (int i = 0; i < Health.MaxHealth; i++)
        {
            healthPoints[i].enabled = i < Health.Health ? true : false;
        }
    }
}
