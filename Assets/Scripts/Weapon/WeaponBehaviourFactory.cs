using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    SingleBullet,
    Shotgun,
    BurstFire,
    SpreadShot
}

public static class WeaponBehaviourFactory
{
    public static IWeaponBehaviour CreateWeaponBehaviour(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.SingleBullet:
                return new SingleBulletWeapon();
            default:
                throw new System.ArgumentException("Invalid weapon type");
        }
    }
}
