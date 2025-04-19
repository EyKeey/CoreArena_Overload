using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Moving,
    Attacking,
}

public class EnemyAI : MonoBehaviour
{
    private Enemy enemy;
    private Transform player;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        player = GameObject.FindWithTag("Player").transform;
    }


    private void Update()
    {
        if (enemy.health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= enemy.attackRange)
        {
            Attack(player);
        }
        else
        {
            MoveTowards(player.position);
        }
    }

    private void MoveTowards(Vector3 position)
    {
        throw new NotImplementedException();
        
    }

    private void Attack(Transform player)
    {
        throw new NotImplementedException();
    }
}
