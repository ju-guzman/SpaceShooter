using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 20.0f;

    public float Health => health;

    public Action DamageReceived;
    public Action Kill;

    public void TakeDamage(float damage)
    {
        health -= damage;
        DamageReceived?.Invoke();
        if (health <= 0)
        {
            Kill?.Invoke();
            Destroy(gameObject);
        }
    }
}
