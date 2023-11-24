using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 20.0f;

    public float Health => health;

    public Action DamageReceived;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        DamageReceived?.Invoke();
    }
}
