using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//******************************************************************//
// <summary>
// ExecuteManager is a singleton class that manages the execution of code blocks in the game.
// It is responsible for executing the effects of code blocks on the player, weapons, and other game elements.
// </summary>
//******************************************************************//

public class ExecuteManager : MonoBehaviour
{
    public static ExecuteManager Instance;

    public PlayerController playerController;

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

    public void ExecuteStat(CodeBlockType blockType ,StatType statType, float stat)
    {
        if(blockType == CodeBlockType.Player)
        {
            playerController.UpdateStat(statType, stat);
        }
    }

    public void ExecuteWeapon(GameObject weaponPrefab)
    {
        Debug.Log("Executing weapon: " + weaponPrefab.name);
    }


}
