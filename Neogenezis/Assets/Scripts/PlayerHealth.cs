using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IAliveObject
{
    [SerializeField] public int Health;
    [SerializeField] public int MaxHealth;
    
    [SerializeField] private AudioSource HealSound;
    [SerializeField] private AudioSource DamageSound;

    [SerializeField] private UnityEvent EventOnTakeDamage;
    [SerializeField] private UnityEvent _eventOnTakeDamageUI;

    public void OnHit(int damage)
    {
        Health -= damage;
        _eventOnTakeDamageUI.Invoke();
        IsAlive(Health);
        
        DamageSound.pitch = Random.Range(1f, 1.2f);
        DamageSound.Play();
        
        EventOnTakeDamage.Invoke();
    }

    public void IsAlive(int health)
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
    }

    public void GetHealthPack()
    {
        Health += 2;
        _eventOnTakeDamageUI.Invoke();
        HealSound.pitch = Random.Range(0.6f, 0.7f);
        HealSound.Play();
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
    }
}
