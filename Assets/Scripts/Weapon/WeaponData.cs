using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 2)]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject bulletPrefab;
    public float fireRate;
    public float bulletsPerShot;
    public float bulletSpeed;
    public float spreadAngle;
    public float bulletLifetime;
    public float damage;
    public float fireCooldown;
    public float reloadTime;
    public WeaponType weaponType;

}
