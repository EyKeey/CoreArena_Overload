using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2Int currentCell;
    public float health = 100f;

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
