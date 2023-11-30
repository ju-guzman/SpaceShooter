using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Ship
{
    [SerializeField] private float damageByCollision = 1f;
    [SerializeField] private float scoreByKill = 100f;

    protected override void Start()
    {
        base.Start();
        if (shotManager && shotManager.FireRatio > 0)
            StartCoroutine(Shoot());
        if (healthManager)
            healthManager.Kill += () => GameManager.Instance.AddScore(scoreByKill);
        Destroy(gameObject, 20f);
    }

    private void Update()
    {
        if (movementManager)
        {
            movementManager.Move(Vector2.left);
        }
    }

    protected override void OnBulletCollision(Collider2D collision, Bullet bulletReference)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthManager player = collision.gameObject.GetComponent<HealthManager>();
            if (player)
                player.TakeDamage(bulletReference.Damage);
            bulletReference.HitBullet();
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            shotManager.Shot();
            yield return new WaitForSeconds(shotManager.FireRatio / fireRatioMultiplier);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KillZone"))
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Player"))
        {
            HealthManager otherHealthManager = collision.gameObject.GetComponent<HealthManager>();
            if (otherHealthManager)
                otherHealthManager.TakeDamage(damageByCollision);
            GameManager.Instance.AddScore(scoreByKill);
            Destroy(gameObject);
        }
    }
}
