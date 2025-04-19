using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TargetingMode
{
    Closest,
    LowestHP,
    HighestHP,
    Random,
}


public class PlayerTargetingSystem : MonoBehaviour
{
    public TargetingMode targetingMode = TargetingMode.Random;
    private Transform currentTarget;
    public float detectionRadius = 10f;

    public Transform UpdateTarget()
    {
        List<Enemy> enemiesInRange = SpatialHashSystem.Instance.GetNearbyEnemies(transform.position, detectionRadius);

        if (enemiesInRange.Count == 0)
        {
            currentTarget = null;
            return currentTarget;
        }

        Enemy target = targetingMode switch
        {
            TargetingMode.Closest => FindClosestEnemy(enemiesInRange),
            TargetingMode.LowestHP => FindLowestHPEnemy(enemiesInRange),
            TargetingMode.HighestHP => FindHighestHPEnemy(enemiesInRange),
            TargetingMode.Random => FindRandomEnemy(enemiesInRange),
            _ => null,
        };

        if (target != null)
        {
            currentTarget = target.transform;
        }
        else
        {
            currentTarget = null;
        }

        return currentTarget;
    }

    private Enemy FindClosestEnemy(List<Enemy> enemiesInRange)
    {
        return enemiesInRange.OrderBy(e => Vector2.Distance(transform.position, e.transform.position)).First();
    }

    private Enemy FindLowestHPEnemy(List<Enemy> enemiesInRange)
    {
        return enemiesInRange.OrderBy(e => e.health).First();
    }

    private Enemy FindHighestHPEnemy(List<Enemy> enemiesInRange)
    {
        return enemiesInRange.OrderByDescending(e => e.health).First();
    }

    private Enemy FindRandomEnemy(List<Enemy> enemiesInRange)
    {
        return enemiesInRange[Random.Range(0, enemiesInRange.Count)];
    }
}
