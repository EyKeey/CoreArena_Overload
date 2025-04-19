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

    public Transform UpdateTarget(float detectionRadius)
    {
        List<Enemy> enemiesInRange = SpatialHashSystem.Instance.GetNearbyEnemies(transform.position, detectionRadius);

        if (enemiesInRange.Count == 0)
        {
            currentTarget = null;
            return currentTarget;
        }

        Enemy target = targetingMode switch
        {
            TargetingMode.Closest => enemiesInRange.OrderBy(e => Vector2.Distance(transform.position, e.transform.position)).First(),
            TargetingMode.LowestHP => enemiesInRange.OrderBy(e => e.health).First(),
            TargetingMode.HighestHP => enemiesInRange.OrderByDescending(e => e.health).First(),
            TargetingMode.Random => enemiesInRange[Random.Range(0, enemiesInRange.Count)],
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
}
