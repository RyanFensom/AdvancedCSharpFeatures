using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class PlayerMovement : MonoBehaviour
    {
        public float acceleration = 200f;
        public float deceleration = .01f;

        private Rigidbody rigid;

        // Use this for initialization
        void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Accelerate();
            Decelerate();
        }

        void Accelerate()
        {
            // Get input
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            // Calculate input direction
            Vector3 inputDir = new Vector3(inputH, 0, inputV);
            // Add force in direction by acceleration
            rigid.AddForce(inputDir * acceleration);
        }

        void Decelerate()
        {
            // velocity = -velocity x deceleration
            rigid.velocity = -rigid.velocity * deceleration;
        }
    }
}