using UnityEngine;

public class Player : Ship
{
    private float timer = 0;
    private int currentBullet = 0;
    private float currentFireRatio = 1f;

    protected override void Start()
    {
        base.Start();
        currentFireRatio = shotManager.ApplyMultiplierRatio ? shotManager.FireRatio / shipStats.fireRateMultiplier : shotManager.FireRatio;
    }

    private void Update()
    {
        PlayerMovement();
        PlayerShot();
        PlayerChangeBullet();
    }


    protected override void DamageReceived(float percent)
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
    private void PlayerChangeBullet()
    {
        if(shotManager)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentBullet--;
                if (currentBullet < 0)
                    currentBullet = shipStats.bullets.Length - 1;
                SetBullet();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentBullet++;
                if (currentBullet > shipStats.bullets.Length - 1)
                    currentBullet = 0;
                SetBullet();
            }
        }
    }

    private void SetBullet()
    {
        shotManager.SetBullet(shipStats.bullets[currentBullet]);
        currentFireRatio = shotManager.ApplyMultiplierRatio ? shotManager.FireRatio / shipStats.fireRateMultiplier : shotManager.FireRatio;
        GameManager.Instance.SwitchAmmo(shipStats.bullets[currentBullet]);
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
            if (Input.GetKey(KeyCode.Space) && timer > (currentFireRatio))
            {
                shotManager.Shot();
                timer = 0;
            }
        }
    }
}
