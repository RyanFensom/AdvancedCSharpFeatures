using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject muzzleFlash;
        public GameObject bulletPrefab;
        public int damage = 10;
        public int ammo = 0;
        public int maxAmmo = 30;
        public float recoil = 5f;
        public float fireInterval = 0.2f;

        public abstract void Fire();

        public virtual void Reload()
        {
            ammo = maxAmmo;
        }

        public Bullets SpawnBullet(Vector3 pos, Quaternion rot)
        {
            // Instantiate a new bullet
            GameObject clone = Instantiate(bulletPrefab, pos, rot);
            Bullets b = clone.GetComponent<Bullets>();
            // >> Play sound here <<

            // >> Play MuzzleFlash <<
            Instantiate(muzzleFlash, pos, rot);
            // Reduce current ammo by 1
            ammo--;
            // return that new bullet
            return b;
        }

    }
}
