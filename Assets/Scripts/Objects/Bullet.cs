using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject render;
    [SerializeField] private SO_Bullet bulletData;

    private Vector2 direction = Vector2.right;
    private Action<Collider2D, Bullet> OnTriggerAction;

    public bool ApplyMultiplierRatio => bulletData.applyMultiplierRatio;
    public bool PlayShootSound => bulletData.playShootSound;
    public Sprite Image => bulletData.image;
    public float Damage => bulletData.damage;
    public float FireRatio => bulletData.fireRatio;


    private void Start()
    {
        this.direction = direction.normalized;
        RotateSprite();
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.transform.Translate(Time.deltaTime * bulletData.speed * direction);
    }

    public void ConfigureBullet(Vector2 direction, Action<Collider2D, Bullet> onTriggerEvent)
    {
        SetDirection(direction);
        OnTriggerAction = onTriggerEvent;
    }

    public void HitBullet()
    {
        if (bulletData.hitEffect != null)
        {
            var effect = Instantiate(bulletData.hitEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
        if (bulletData.destroyOnHit)
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
