using UnityEngine;

public enum AttackType
{
    Melee,
    Ranged,
    Knockback,
    AreaOfEffect
}

[CreateAssetMenu(fileName = "EnemyType", menuName = "ScriptableObjects/EnemyType", order = 1)]
public class EnemyData: ScriptableObject
{
    public string enemyName;
    public int health;
    public int attackDamage;
    public float speed;
    public float attackRange;
    public float attackCooldown;
    public float detectionRange;
    public GameObject bulletPrefab;
    public AttackType attackType;

    // Add any other properties or methods you need for your enemy type
}