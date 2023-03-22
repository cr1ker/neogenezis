using UnityEngine;
using UnityEngine.Events;
using Slider = UnityEngine.UI.Slider;

public class EnemyHealth : MonoBehaviour, IGunDamage, IEnemyHealthBar
{
    public int Health;
    public UnityEvent GetDamage;
    [SerializeField] private Slider _healthBar;

    private void Start()
    {
        
        _healthBar.maxValue = Health;
        ChangeValueHealthBar(Health);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            Health -= GunDamage();
            GetDamage.Invoke();
            ChangeValueHealthBar(Health);
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody?.GetComponent<Bullet>())
        {
            Health -= GunDamage();
            GetDamage.Invoke();
            ChangeValueHealthBar(Health);
            if (Health <= 0)
            {
                Destroy(this.gameObject); 
            }
        }
        else
        {
            Debug.Log("lox");
        }
    }
    
    public int GunDamage()
    {
        return FindObjectOfType<Gun>().GetGunDamage();
    }

    public void ChangeValueHealthBar(int healthValue)
    {
        _healthBar.value = healthValue;
    }
}
