using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class Attack : MonoBehaviour
    {
        public int damage = 10;

        protected virtual void OnTriggerEnter(Collider other)
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                // Deal damage in that object
                health.TakeDamage(damage);
            }
        }

    }
}

