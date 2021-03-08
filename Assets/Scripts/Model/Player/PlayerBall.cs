using System.Collections;
using UnityEngine;

namespace LabirintSpace

    {
    public sealed class PlayerBall : PlayerBase
        {
        private Rigidbody _rigidbody;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        private void Start()
            {
            _rigidbody = GetComponent<Rigidbody>();
            }

        public override void Move(float x, float y, float z)
            {
            _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
            }
        }
    }