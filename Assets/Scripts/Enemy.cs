using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2Int currentCell;


    [Header("Enemy Settings")]
    public float health = 100f;
    public float movementSpeed = 3f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackCooldown = 1f;
    public float attackTimer = 0f;
    public float attackDuration = 0.5f;


    private void Start()
    {
        // Register the enemy in the spatial hash system
        SpatialHashSystem.Instance.RegisterEnemy(this);
    }

    private void Update()
    {
        SpatialHashSystem.Instance.UpdateEnemyCell(this);

    }

    private void OnDestroy()
    {
        // Unregister the enemy from the spatial hash system
        SpatialHashSystem.Instance.RemoveEnemy(this);
    }
}
