using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController component not found on this GameObject.");
        }
    }


    public void UpdateStat(StatType statType, float stat)
    {
        switch (statType)
        {
            case StatType.Health:
                Debug.Log("Updating Health: " + stat);
                break;
            case StatType.Damage:
                Debug.Log("Updating Damage: " + stat);
                break;
            case StatType.Speed:
                playerController.movementSpeed = stat;
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
