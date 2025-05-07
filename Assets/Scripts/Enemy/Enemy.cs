using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2Int currentCell;
    public EnemyData enemyData;
    public int health;

    private IEnemyBehaviour enemyBehaviour;

    private void Awake()
    {
        // Initialize the enemy's health and behavior based on the enemy data
        health = enemyData.health;
        enemyBehaviour = EnemyBehaviorFactory.CreateBehaviour(enemyData, this);
    }

    private void Start()
    {
        // Register the enemy in the spatial hash system
        SpatialHashSystem.Instance.RegisterEnemy(this);
    }

    private void Update()
    {
        SpatialHashSystem.Instance.UpdateEnemyCell(this);
        enemyBehaviour.UpdateBehaviour();
    }

    private void OnDestroy()
    {
        // Unregister the enemy from the spatial hash system
        SpatialHashSystem.Instance.RemoveEnemy(this);
    }
}
