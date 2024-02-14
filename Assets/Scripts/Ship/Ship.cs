using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] protected SO_Ship shipStats;
    [SerializeField] protected ParticleSystem deatEffect;

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

    virtual protected void DamageReceived(float percent)
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
            healthManager.OnHealthChanged = DamageReceived;
    }
}
