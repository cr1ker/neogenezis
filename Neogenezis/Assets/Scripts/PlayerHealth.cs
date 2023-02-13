using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IAliveObject
{
    public int Health;
    public int MaxHealth;
    
    public AudioSource HealSound;
    public AudioSource DamageSound;

    [SerializeField] private int _respawnScene;
    
    public UnityEvent EventOnTakeDamage;
    
    public void OnHit(int damage)
    {
        Health -= damage;
        IsAlive(Health);
        
        DamageSound.pitch = Random.Range(1f, 1.2f);
        DamageSound.Play();
        
        EventOnTakeDamage.Invoke();
    }

    public void IsAlive(int health)
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(_respawnScene);
            return;
        }
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
