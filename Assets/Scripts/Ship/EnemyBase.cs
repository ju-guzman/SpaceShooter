using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : Ship
{
    [SerializeField] private Slider healthBar;

    protected override void Start()
    {
        base.Start();
        if (shotManager && shotManager.FireRatio > 0)
            StartCoroutine(Shoot());
        if (healthManager)
        {
            healthManager.Kill += () =>
            {
                GameManager.Instance.AddScore(shipStats.scoreByKill);
                if (deatEffect)
                {
                    ParticleSystem effect = Instantiate(deatEffect, transform.position, Quaternion.identity);
                    effect.Play();
                    Destroy(effect.gameObject, effect.main.duration);
                }
            };
            healthManager.OnHealthChanged = (percent) => healthBar.value = percent;
        }
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
            yield return new WaitForSeconds(shotManager.FireRatio / shipStats.fireRateMultiplier);
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
                otherHealthManager.TakeDamage(shipStats.damageByCollision);
            GameManager.Instance.AddScore(shipStats.scoreByKill);
            GameManager.Instance.PlayExplosionSound();
            Destroy(gameObject);
        }
    }
}
