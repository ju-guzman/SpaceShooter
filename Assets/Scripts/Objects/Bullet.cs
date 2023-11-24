using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject render;
    [SerializeField] private bool destroyOnHit;
    [SerializeField] private float fireRatio;

    private Vector2 direction = Vector2.right;
    private Action<Collider2D, Bullet> OnTriggerAction;

    public float Damage => damage;
    public float FireRatio => fireRatio;


    private void Start()
    {
        this.direction = direction.normalized;
        RotateSprite();
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.transform.Translate(Time.deltaTime * speed * direction);
    }

    public void ConfigureBullet(Vector2 direction, Action<Collider2D, Bullet> onTriggerEvent)
    {
        SetDirection(direction);
        OnTriggerAction = onTriggerEvent;
    }

    public void HitBullet()
    {
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerAction?.Invoke(collision, this);
        if (collision.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }

    private void SetDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
        RotateSprite();
    }

    private void RotateSprite()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        render.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
