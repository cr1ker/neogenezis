using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    
    public AudioSource HealSound;
    public AudioSource DamageSound;

    public UnityEvent EventOnTakeDamage;
    
    public void OnHit(int damage)
    {
        Health -= damage;
        
        DamageSound.pitch = Random.Range(1f, 1.2f);
        DamageSound.Play();
        
        EventOnTakeDamage.Invoke();
    }

    public void GetHealthPack()
    {
        Health += 1;
        HealSound.pitch = Random.Range(0.6f, 0.7f);
        HealSound.Play();
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
    }
}
