using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehaviour : IEnemyBehaviour
{
    private Enemy enemy;
    private Transform player;

    private float lastAttackTime = 0f;


    public RangedBehaviour(Enemy enemy)
    {
        this.enemy = enemy;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void UpdateBehaviour()
    {
        if(player == null)
        {
            return;
        }

        // Check if the player is within attack range
        float distanceToPlayer = Vector2.Distance(enemy.transform.position, player.position);
    
        if(distanceToPlayer <= enemy.enemyData.attackRange)
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
        GameObject bullet = GameObject.Instantiate(enemy.enemyData.bulletPrefab, enemy.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * enemy.enemyData.attackDamage;
    }
}
