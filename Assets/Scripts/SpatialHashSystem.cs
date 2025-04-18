using System.Collections.Generic;
using UnityEngine;


//***********************************************************//
// This script implements a spatial hash system for managing enemies in a grid.
// It allows for efficient querying of nearby enemies based on their positions.
// The grid is divided into cells, and each enemy is registered to a specific cell.
// The system updates the enemy's cell when they move, and it can retrieve a list of nearby enemies within a specified radius.
//***********************************************************//

public class SpatialHashSystem : MonoBehaviour
{
    public static SpatialHashSystem Instance;

    public int gridSize = 10;

    private Dictionary<Vector2Int, List<Enemy>> grid = new Dictionary<Vector2Int, List<Enemy>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private Vector2Int WorldToCell(Vector2 position)
    {
        int x = Mathf.FloorToInt(position.x / gridSize);
        int y = Mathf.FloorToInt(position.y / gridSize);
        return new Vector2Int(x, y);
    }

    public void RegisterEnemy(Enemy enemy)
    {
        Vector2Int cell = WorldToCell(enemy.transform.position);
        if (!grid.ContainsKey(cell))
        {
            grid[cell] = new List<Enemy>();
        }

        grid[cell].Add(enemy);
        enemy.currentCell = cell;
    }

    public void UpdateEnemyCell(Enemy enemy)
    {
        Vector2Int newCell = WorldToCell(enemy.transform.position);

        if (newCell != enemy.currentCell)
        {
            // Remove enemy from the old cell
            if (grid.TryGetValue(enemy.currentCell, out var oldList))
                oldList.Remove(enemy);

            // Add enemy to the new cell
            if (!grid.ContainsKey(newCell))
                grid[newCell] = new List<Enemy>();

            grid[newCell].Add(enemy);
            enemy.currentCell = newCell;
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (grid.TryGetValue(enemy.currentCell, out var cellList))
        {
            cellList.Remove(enemy);
            if (cellList.Count == 0)
            {
                grid.Remove(enemy.currentCell);
            }
        }
    }

    public List<Enemy> GetNearbyEnemies(Vector2 pos, float radius)
    {
        List<Enemy> nearbyEnemies = new List<Enemy>();
        int cellRadius = Mathf.CeilToInt(radius / gridSize);
        Vector2Int centerCell = WorldToCell(pos);

        for (int x = -cellRadius; x <= cellRadius; x++)
        {
            for (int y = -cellRadius; y <= cellRadius; y++)
            {
                Vector2Int cell = new Vector2Int(centerCell.x + x, centerCell.y + y);
                if (grid.TryGetValue(cell, out var enemies))
                {
                    foreach (var enemy in enemies)
                    {
                        if (Vector2.Distance(enemy.transform.position, pos) <= radius)
                        {
                            nearbyEnemies.Add(enemy);
                        }
                    }
                }
            }
        }

        return nearbyEnemies;
    }
}
