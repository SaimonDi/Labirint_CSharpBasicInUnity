using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LabirintSpace
    {
    public class Player : MonoBehaviour
        {
        public float Speed = 3.0f;
        private Rigidbody m_rigidbody;
        public bool immortal;

        private void Start()
            {
            m_rigidbody = GetComponent<Rigidbody>();
            }

        protected void Move()
            {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            m_rigidbody.AddForce(movement * Speed);
            }
        }
    }
