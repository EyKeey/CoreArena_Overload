using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public enum TargetingMode
{
    Closest,
    LowestHP,
    HighestHP,
    Random,
}

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float movementSpeed = 5f;
    public float detectionRadius = 10f;

    public TargetingMode targetingMode = TargetingMode.Random; 

    private Rigidbody2D rb;
    private Transform currentTarget;
    private Vector2 randomDirection;
    private float randomTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateTarget();

        if (currentTarget != null)
        {
            MoveTowards(currentTarget.position);
        }
        else
        {
            Wander();
        }
    }


    private void UpdateTarget()
    {
        List<Enemy> enemiesInRange = SpatialHashSystem.Instance.GetNearbyEnemies(transform.position, detectionRadius);
        
        if (enemiesInRange.Count == 0)
        {
            currentTarget = null;
            return;
        }

        Enemy target = targetingMode switch
        {
            TargetingMode.Closest => enemiesInRange.OrderBy(e => Vector2.Distance(transform.position, e.transform.position)).First() ,
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
    }
    private void MoveTowards(Vector2 position)
    {
        Vector2 dir  =  (position - (Vector2)transform.position).normalized;
        transform.position += (Vector3)dir * movementSpeed * Time.deltaTime;
    }

    private void Wander()
    {
        randomTime -= Time.deltaTime;

        if (randomTime <= 0f)
        {
            float angle = Random.Range(0f, 360f);
            randomDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            randomTime = Random.Range(1f, 2f);
        }

        transform.position += (Vector3)randomDirection.normalized * movementSpeed * Time.deltaTime;
    }


    

}
