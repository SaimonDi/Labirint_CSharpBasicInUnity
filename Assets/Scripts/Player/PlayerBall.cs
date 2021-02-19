using System.Collections;
using UnityEngine;

namespace LabirintSpace

    {
    public sealed class PlayerBall : Player
        {
        private void FixedUpdate()
            {
            Move();
            }
        }
    }