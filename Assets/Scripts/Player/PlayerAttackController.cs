using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private PlayerTargetingSystem targetingSystem;
    private Animator animator;

    private float lastAttackTime = 0f; // Time of the last attack
    public float cooldownTime = 1f; // Time in seconds between attacks
    public float attackRange = 5f; // Range of the attack
    private float damage = 10f; // Damage dealt by the attack

    private void Start()
    {
        targetingSystem = GetComponent<PlayerTargetingSystem>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time >= lastAttackTime + cooldownTime)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    private void Attack()
    {
    
        Transform currentTarget = targetingSystem.UpdateTarget();
        
        if(currentTarget == null)
        {
            Debug.Log("No target in range.");
            return;
        }

        float distanceToTarget = Vector2.Distance(transform.position, currentTarget.position);
        
        if (distanceToTarget <= attackRange)
        {
            MeleeAttack(currentTarget);
        }
        else
        {
            Debug.Log("Target is out of range.");
        }

    }

    private void MeleeAttack(Transform enemy)
    {
        animator.SetTrigger("Attack1");
        enemy.GetComponent<Enemy>().health -= damage;   
        Debug.Log("Attacked " + enemy.name + " for " + damage + " damage.");
    }
}
