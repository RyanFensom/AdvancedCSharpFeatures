using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    public class Shooting : MonoBehaviour
    {
        public int weaponIndex = 0;

        private Weapon[] attachedWeapons;
        private Rigidbody2D rigid;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            attachedWeapons = GetComponentsInChildren<Weapon>();
        }

        void Start()
        {
            SwitchWeapon(weaponIndex);
        }

        void Update()
        {
            CheckFire();

            // IF q is pressed
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CycleWeapon(-1);
            }

            // IF e is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                CycleWeapon(1);
            }
        }


        void CheckFire()
        {
            // SET currentWeapon to ttachedWeapons[weaponIndex]
            Weapon currentWeapon = attachedWeapons[weaponIndex];
            // IF space is down
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Fire currentWeapon
                currentWeapon.Fire();
                // Apply currentWeapon's recoil to player
                rigid.AddForce(-transform.right * currentWeapon.recoil, ForceMode2D.Impulse);
            }
        }

        void CycleWeapon(int amount)
        {
            // SET desiredIndex to weaponIndex + amount
            int desiredIndex = weaponIndex + amount;
            // IF desiredIndex >= weapons length
            if (desiredIndex >= attachedWeapons.Length)
            {
                // SET desiredIndex to zero
                desiredIndex = 0;
            }
            // ELSE IF desiredIndex < zero
            else if (desiredIndex < 0)
            {
                // SET desiredIndex to weapons length - 1
                desiredIndex = attachedWeapons.Length - 1;
            }

            // SET weaponIndex to desiredIndex
            weaponIndex = desiredIndex;
            // SwitchWeapon() and pass weaponIndex
            SwitchWeapon(weaponIndex);
        }

        Weapon SwitchWeapon(int weaponIndex)
        {
            // Check bounds
            if (weaponIndex < 0 || weaponIndex > attachedWeapons.Length)
            {
                // Return null as Error
                return null;
            }

            // Loop through all attachedWeapons
            for (int i = 0; i < attachedWeapons.Length; i++)
            {
                // SET w to attachedWeapons[i]
                Weapon w = attachedWeapons[i];
                // IF i == weaponIndex
                if (i == weaponIndex)
                {
                    // Activate gameObject in w variable
                    w.gameObject.SetActive(true);
                }
                // ELSE
                else
                {
                    // Deactivate gameobject in w variable
                    w.gameObject.SetActive(false);
                }
            }

            return attachedWeapons[weaponIndex];
        }
    }
}
