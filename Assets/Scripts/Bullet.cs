using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    private float lifetime;
    private float damage;

    private BulletPool bulletPool;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void Initialize(Vector2 rotatedDirection, float bulletSpeed, float bulletLifetime, float bulletDamage, BulletPool pool)
    {
        direction = rotatedDirection;
        speed = bulletSpeed;
        lifetime = bulletLifetime;
        damage = bulletDamage;
        bulletPool = pool;

        CancelInvoke();
        Invoke("DestroyBullet", lifetime);
    }

    public void DestroyBullet()
    {
        bulletPool.ReturnBullet(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            DestroyBullet();
        }
        else if (collision.CompareTag("Wall"))
        {
            DestroyBullet();
        }
    }

}
