using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStat playerStat;
    private PlayerController playerController;

    private void Start()
    {
        playerStat = GetComponent<PlayerStat>();
        playerController = GetComponent<PlayerController>();
    }

    public bool TakeDamage(int damage)
    {
        if (playerController.IsUntouchable) return false;

        playerStat.currentHealth -= damage;
        if (playerStat.currentHealth <= 0)
        {
            Die();
            return false;
        }
        return true;
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Player died");
    }
}
