using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 10f;
        public float lookSpeed = 10f;
        public float jumpSpeed = 100f;
        public Camera cam;

        private bool isGrounded = false;
        private Rigidbody rigid; 
        private float pitch, yaw;       

        // Use this for initialization
        void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

        public void Move(float h, float v)
        {
            Vector3 position = rigid.position;

            position += transform.forward * v * moveSpeed * Time.deltaTime;
            position += transform.right * h * moveSpeed * Time.deltaTime;

            rigid.MovePosition(position);
        }

        public void Look(float h, float v)
        {
            yaw += h * lookSpeed * Time.deltaTime;
            pitch += v * lookSpeed * Time.deltaTime;

            transform.eulerAngles = new Vector3(0, yaw, 0);
            cam.transform.localEulerAngles = new Vector3(-pitch, 0, 0);
        }

        public void Jump()
        {
            if (isGrounded)
            {
                rigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                isGrounded = false;
            }    
        }

        void OnCollisionEnter(Collision col)
        {
            isGrounded = true;
        }
    }
}

