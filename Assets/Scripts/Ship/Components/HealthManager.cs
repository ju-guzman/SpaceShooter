using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 20.0f;
    private float maxHealth;

    public float Health => health;

    public Action<float> OnHealthChanged;
    public Action Kill;

    public void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        OnHealthChanged?.Invoke(health/maxHealth);
        if (health <= 0)
        {
            Kill?.Invoke();
            GameManager.Instance.PlayExplosionSound();
            Destroy(gameObject);
        }
    }

    public void Heal()
    {
        health = maxHealth;
        OnHealthChanged?.Invoke(1);
    }
}
