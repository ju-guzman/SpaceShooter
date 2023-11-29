using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    [SerializeField] private Transform[] bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector2 bulletDirection;

    public float FireRatio => bulletPrefab.GetComponent<Bullet>().FireRatio;
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
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().ConfigureBullet(bulletDirection, OnBulletCollision);
    }

    internal void SetBullet(GameObject newBullet)
    {
        bulletPrefab = newBullet;
    }
}
