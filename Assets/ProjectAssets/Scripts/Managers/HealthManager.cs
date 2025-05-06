using System;
using System.Diagnostics.Tracing;
using Assets.ProjectAssets.Scripts.GameEvents;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    //public event Action<int, int> OnHealthChanged;
    //public event Action<int> OnDamaged;
    //public event Action<int> OnHealed;

    [SerializeField] private GameIntEvent onHurt;
    [SerializeField] private GameIntEvent onCure;

    public event Action OnDeath;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        //OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            onHurt.Raise(1);
            //TakeDamage(1);
        }
        if (collision.transform.GetComponent<ColorObject>())
        {
            if(collision.transform.GetComponent<ColorObject>().color == GetComponent<ColorMechanic>().color)
            {
                onHurt.Raise(1);
                //TakeDamage(1);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hearth")
        {
            //Heal(1);
            onCure.Raise(1);
            Destroy(collision.gameObject);
        }
    }
    public void TakeDamage(int amount)
    {
        if (CurrentHealth <= 0) return;

        CurrentHealth -= amount;
        CurrentHealth = Mathf.Max(CurrentHealth, 0);

        //OnDamaged?.Invoke(amount);
        //OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

        if (CurrentHealth == 0)
        {
            OnDeath?.Invoke();
        }
    }
    public void Heal(int amount)
    {
        if (CurrentHealth <= 0) return;

        CurrentHealth += amount;
        CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth);

        //OnHealed?.Invoke(amount);
        //OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }
}