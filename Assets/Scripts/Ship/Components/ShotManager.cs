using System;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    [SerializeField] private Transform[] bulletSpawn;
    [SerializeField] private SO_Bullet bulletData;
    [SerializeField] private Vector2 bulletDirection;
    [SerializeField] private AudioSource bulletSound;

    public float FireRatio => bulletData.fireRatio;
    public bool ApplyMultiplierRatio => bulletData.applyMultiplierRatio;
    public Action<Collider2D, Bullet> OnBulletCollision;

    private void Awake()
    {
        bulletDirection = bulletDirection.normalized;
    }

    public void Shot()
    {
        foreach (var bulletSpawnPoint in bulletSpawn)
        {
            Shot(bulletSpawnPoint);
        }
    }

    private void Shot(Transform bulletSpawnPoint)
    {
        var bullet = Instantiate(bulletData.prefabToSpawn, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().ConfigureBullet(bulletDirection, OnBulletCollision);
        if(bullet.PlayShootSound)
        {
            bulletSound.Play();
        }
    }

    internal void SetBullet(SO_Bullet newBullet)
    {
        bulletData = newBullet;
    }
}
