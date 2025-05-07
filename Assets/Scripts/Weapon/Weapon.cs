using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public Transform firePoint;
    public BulletPool bulletPool;

    private IWeaponBehaviour weaponBehaviour;
    private PlayerInput playerInput;
    private float fireCooldownTimer = 0f;
    private bool isReloading = false;
    public int currentAmmo = 20;
    private int maxAmmo = 20;

    private void Start()
    { 
        weaponBehaviour = WeaponBehaviourFactory.CreateWeaponBehaviour(weaponData.weaponType);
    }

    public void Fire()
    {
        if (isReloading) return;
        weaponBehaviour.Fire(this);
    }

    public void UseAmmo(int amount)
    {
        currentAmmo -= amount;
        if (currentAmmo <= 0)
        {
            TryReload();
        }
    }

    public void TryReload()
    {
        if (currentAmmo < maxAmmo && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    public IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        isReloading = true;
        yield return new WaitForSeconds(weaponData.reloadTime);
        isReloading = false;
        currentAmmo = maxAmmo;
    }

}

