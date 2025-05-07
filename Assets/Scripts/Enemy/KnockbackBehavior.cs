using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackBehavior : IEnemyBehaviour
{
    private Enemy enemy;
    private Transform player;
    private float lastAttackTime = 0f;

    public KnockbackBehavior(Enemy enemy)
    {
        this.enemy = enemy;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void UpdateBehaviour()
    {
        if (player == null)
        {
            return;
        }

        Vector2 distance = player.position - enemy.transform.position;

        if(distance.magnitude <= enemy.enemyData.attackRange)
        {
            // Check if the cooldown has passed
            if (Time.time >= lastAttackTime + enemy.enemyData.attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }

    }

    private void Attack()
    {
        Vector2 direction = (player.position - enemy.transform.position).normalized;
        enemy.gameObject.GetComponent<Rigidbody2D>().velocity = direction * enemy.enemyData.speed;
    }
    
}
