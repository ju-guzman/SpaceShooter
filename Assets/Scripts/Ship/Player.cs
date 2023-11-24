using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private float timer = 0;

    private void Update()
    {
        PlayerMovement();
        PlayerShot();
    }

    protected override void DamageReceived()
    {
        if (healthManager)
            GameManager.Instance.PlayerLifeUpdate(healthManager.Health);
    }

    protected override void OnBulletCollision(Collider2D collision, Bullet bulletReference)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthManager enemy = collision.gameObject.GetComponent<HealthManager>();
            if (enemy)
                enemy.TakeDamage(bulletReference.Damage);
            bulletReference.HitBullet();
        }
    }

    private void PlayerMovement()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        movementManager.Move(new Vector2(inputH, inputV));
    }

    private void PlayerShot()
    {
        if (shotManager)
        {
            timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) && timer > (shotManager.FireRatio / fireRatioMultiplier))
            {
                shotManager.Shot();
                timer = 0;
            }
        }
    }
}
