using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBulletWeapon : IWeaponBehaviour
{
    public void Fire(Weapon weapon)
    {

        Vector2 lookPos = InputManager.Instance.lookInput;
        Vector2 lookWorldPos = Camera.main.ScreenToWorldPoint(lookPos);

        Vector2 fireDirection = (lookWorldPos - (Vector2)weapon.firePoint.position).normalized;

        for (int i = 0; i < weapon.weaponData.bulletsPerShot; i++)
        {
            float angle = UnityEngine.Random.Range(-weapon.weaponData.spreadAngle, weapon.weaponData.spreadAngle);
            Vector2 rotatedDirection = Quaternion.Euler(0, 0, angle) * fireDirection;

            GameObject bullet = weapon.bulletPool.GetBullet();
            bullet.transform.position = weapon.firePoint.position;
            bullet.transform.rotation = Quaternion.identity;

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Initialize(rotatedDirection, weapon.weaponData.bulletSpeed, weapon.weaponData.bulletLifetime, weapon.weaponData.damage, weapon.bulletPool);
            weapon.UseAmmo(1);
        }
    }
}
