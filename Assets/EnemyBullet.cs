using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform player;
    private Vector3 direction = new Vector3(0, 0, 1);
    public float speed = 10f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        direction = player.position - transform.position;
    }

    private void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // Destroy the bullet after 2 seconds
        Destroy(gameObject, 2f);
    }
}
