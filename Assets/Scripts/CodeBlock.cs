using System;
using System.Collections.Generic;
using UnityEngine;

public enum CodeBlockType
{
    Player,
    Enemy,
    Weapon,
    Environment,
    Level,
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
}

public enum Category
{
    Weapon,
    Stat,
    Ability,
}

public enum StatType
{
    Health,
    Damage,
    Speed,
    Defense,
    Mana,
}

//**************************************************************************//
// summary:
// This is a scriptable object that represents a code block in the game.
// It contains information about the block, such as its name, type, rarity,
// category, and any associated weapon prefab or stat value.
// The Execute method is responsible for executing the code block's effect
// when called. The block can affect the player, weapon, or other game
// elements based on its category.
// The ExecuteManager is responsible for managing the execution of code
// blocks and applying their effects to the game.
// The code block can be used to create a variety of effects in the game,
// such as modifying player stats, spawning weapons, or triggering abilities.
// The code is designed to be extensible, allowing for the addition of new
// block types, categories, and effects in the future.
//**************************************************************************//

[CreateAssetMenu(fileName = "NewCodeBlock", menuName = "CodeBlock")]
public class CodeBlock : ScriptableObject
{
    public string blockName;
    public string codeSnippet;
    public string description;

    public CodeBlockType blockType;
    public Rarity rarity;
    public Category category;

    public GameObject weaponPrefab;
    public StatType statType;
    public float statValue;
    
    public bool isStandalone;
    public List<CodeBlockType> validParentTypes;

    public void Execute()
    {


        switch (category)
        {
            case Category.Weapon:
                if (weaponPrefab != null)
                {
                    ExecuteManager.Instance.ExecuteWeapon(weaponPrefab);
                }
                break;

            case Category.Stat:
                
                ExecuteManager.Instance.ExecuteStat(blockType, statType, statValue);
                break;

            case Category.Ability:

                break;
        }
    }
}
