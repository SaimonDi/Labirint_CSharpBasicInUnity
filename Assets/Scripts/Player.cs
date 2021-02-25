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
        public Color _playerColor;

        private void Start()
            {
            m_rigidbody = GetComponent<Rigidbody>();
            _playerColor = GetComponent<Renderer>().material.color;
            }

        protected void Move()
            {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            m_rigidbody.AddForce(movement * Speed);
            }

        public void PlayerSpeedUp(bool args, Color color)
            {
            gameObject.GetComponent<Renderer>().material.color = color;
            if(args)
                {
                Speed = 10f;
                }
            else
                {
                Speed = 3f;
                }
            }
        public void PlayerImmortal(bool args)
            {
            if(args)
                {
                immortal = true;
                }
            else
                {
                immortal = false;
                }
            }

        }
    }
