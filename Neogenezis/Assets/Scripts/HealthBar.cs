using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{  
    [SerializeField] private RawImage[] healthPoints;
    [SerializeField] private PlayerHealth Health;

    private void Start()
    {
        Health.Health = Health.MaxHealth; 
    }
    
    public void HealthFiller()
    {
        for (int i = 0; i < Health.MaxHealth; i++)
        {
            healthPoints[i].enabled = i < Health.Health ? true : false;
        }
    }
}
