using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private PlayerTargetingSystem targetingSystem;
    private Animator animator;

    private float lastAttackTime; // Time of the last attack
    public float cooldownTime; // Time in seconds between attacks
    public float attackRange;
    private float damage; // Damage dealt by the attack

    private void Start()
    {
        targetingSystem = GetComponent<PlayerTargetingSystem>();
        animator = GetComponent<Animator>();
    }

    public void Attack(Transform currentTarget)
    {   
        if (currentTarget == null)
        {
            Debug.Log("No target in range.");
            return;
        }

        PlayerController playerController = GetComponent<PlayerController>();
        playerController.currentState = PlayerState.Attacking;
        playerController.attackTimer = playerController.attackDuration;
    
        MeleeAttack(currentTarget);
    }

    private void MeleeAttack(Transform enemy)
    {
        animator.SetTrigger("Attack1");
        enemy.GetComponent<Enemy>().health -= 20;   
        Debug.Log("Attacked " + enemy.name + " for " + damage + " damage.");
    }
}
