using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullets : MonoBehaviour
    {
        public float speed = 10f;
        public float aliveDistance = 5f;

        private Rigidbody2D rigid;
        private Vector3 shotPos;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Use this for initialization
        void Start()
        {
            shotPos = transform.position;
        }

        // Update is called once per frame
        public void Fire(Vector3 direction, float? speed = null)
        {
            float curSpeed = this.speed;
            // Check if speed has been used
            if (speed != null)
            {
                curSpeed = speed.Value;
            }
            // Fire off in that direction with curSpeed
            rigid.AddForce(direction * curSpeed, ForceMode2D.Impulse);
        }
    }
}

