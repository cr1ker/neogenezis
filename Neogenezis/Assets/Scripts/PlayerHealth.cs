using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IAliveObject
{
    [Header("Player Health")]
    [SerializeField] public int Health;
    [SerializeField] public int MaxHealth;
    [Header("Player Sounds")]
    [SerializeField] private AudioSource HealSound;
    [SerializeField] private AudioSource DamageSound;
    [Header("Events")]
    [SerializeField] private UnityEvent _eventOnLoseHealth;
    [SerializeField] private UnityEvent _eventOnChangeValueOfHealthBar;
    [SerializeField] private UnityEvent _eventOnTakeHealth;
    [Header("Animations")]
    [SerializeField] private Animator _diePlayerAnimation;

    private string _isPlayerDie = "IsPlayerDie";

    public void OnHit(int damage)
    {
        Health -= damage;
        _eventOnChangeValueOfHealthBar.Invoke();
        IsAlive(Health);
        if (Health > 0)
        {
            _eventOnLoseHealth.Invoke();
            DamageSound.pitch = Random.Range(1f, 1.2f);
            DamageSound.Play();
        }
    }

    public void IsAlive(int health)
    {
        if (health <= 0)
        {
            _diePlayerAnimation.SetBool(_isPlayerDie, true);
            PlayerMover movingController = gameObject.GetComponent<PlayerMover>();
            movingController.ChangeValueOfMovingController(false);
            IEnumerator restartAction = FindObjectOfType<LevelMessage>().SetRestartAction();
            StartCoroutine(restartAction);
        }
    }

    public void GetHealthPack()
    {
        Health += 2;
        _eventOnChangeValueOfHealthBar.Invoke();
        _eventOnTakeHealth.Invoke();
        HealSound.pitch = Random.Range(0.6f, 0.7f);
        HealSound.Play();
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
    }
}
