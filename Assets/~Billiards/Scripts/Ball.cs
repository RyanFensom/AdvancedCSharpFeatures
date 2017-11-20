using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class Ball : MonoBehaviour
    {
        public float stopSpeed = 0.2f;

        private Rigidbody rigid;

        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            // Check if velocity is going up
            if (vel.y >0)
            {
                // Cap velocity
                vel.y =0;
            }

            // IF the velocity's speed is less than the stop speed
            if (vel.magnitude < stopSpeed)
            {
                // Cancel out velocity
                vel = Vector3.zero;
            }

            rigid.velocity = vel;
        }

        // Perform physics impact
        public void Hit(Vector3 dir, float impactForce)
        {
            rigid.AddForce(dir * impactForce, ForceMode.Impulse);
        }
    }
}

