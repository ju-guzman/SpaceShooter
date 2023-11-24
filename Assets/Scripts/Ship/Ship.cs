using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Ship : MonoBehaviour
{
    [SerializeField] protected float fireRatioMultiplier = 1f;

    protected ShotManager shotManager;
    protected MovementManager movementManager;
    protected HealthManager healthManager;

    protected virtual void Start()
    {
        LoadManagers();
    }

    virtual protected void OnBulletCollision(Collider2D collision, Bullet bulletReference)
    {

    }

    virtual protected void DamageReceived()
    {

    }

    private void LoadManagers()
    {
        shotManager = GetComponent<ShotManager>();
        if (shotManager)
            shotManager.OnBulletCollision = OnBulletCollision;

        movementManager = GetComponent<MovementManager>();

        healthManager = GetComponent<HealthManager>();
        if (healthManager)
            healthManager.DamageReceived = DamageReceived;
    }
}
