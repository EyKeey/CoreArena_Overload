using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * movementSpeed;


        var nearbyEnemies = SpatialHashSystem.Instance.GetNearbyEnemies(transform.position, 15f);
        Debug.Log("Nearby Enemies: " + nearbyEnemies.Count);
    }
    public void UpdateStat(StatType statType, float stat)
    {
        switch(statType) {
            case StatType.Health:
                Debug.Log("Updating Health: " + stat);
                break;
            case StatType.Damage:
                Debug.Log("Updating Damage: " + stat);
                break;
            case StatType.Speed:
                movementSpeed = stat;
                break;
            case StatType.Defense:
                Debug.Log("Updating Defense: " + stat);
                break;
            case StatType.Mana:
                Debug.Log("Updating Mana: " + stat);
                break;
        }
    }

}
