using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyBehaviorFactory
{
    public static IEnemyBehaviour CreateBehaviour(EnemyData enemyData, Enemy enemy)
    {
        return enemyData.attackType switch
        {
            AttackType.Ranged => new RangedBehaviour(enemy),
            AttackType.Knockback => new KnockbackBehavior(enemy),
            _ => throw new System.ArgumentException("Invalid attack type")
        };
    }
}
