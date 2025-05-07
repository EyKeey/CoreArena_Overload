using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth;
    public float currentHealth;

    [Header("Mana")]
    public float maxMana;
    public float currentMana;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Dash")]
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;


}
