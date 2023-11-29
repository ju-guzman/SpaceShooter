using UnityEngine;

public class Player : Ship
{
    private float timer = 0;
    private int currentBullet = 0;

    [SerializeField] GameObject[] Bullets;

    private void Update()
    {
        PlayerMovement();
        PlayerShot();
        PlayerChangeBullet();
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
    private void PlayerChangeBullet()
    {
        if(shotManager)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentBullet--;
                if (currentBullet < 0)
                    currentBullet = Bullets.Length - 1;
                shotManager.SetBullet(Bullets[currentBullet]);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentBullet++;
                if (currentBullet > Bullets.Length - 1)
                    currentBullet = 0;
                shotManager.SetBullet(Bullets[currentBullet]);
            }

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
