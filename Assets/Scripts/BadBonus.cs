using System.Collections;
using UnityEngine;

namespace LabirintSpace
    {
    public sealed class BadBonus : InteractiveObject, IFly, IRotation, ICloneable
        {
        private float _lengthFly;
        private float _speedRotation;
        private Player _player;


        private void Awake()
            {
            _lengthFly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            _player = FindObjectOfType<Player>();
            }
        protected override void Interaction()
            {
            //bad bonus
            AddBadBonus();
            }

        private void AddBadBonus()
            {
            var rnd = Random.Range(1, 2);
            if(rnd == 1)
                {
                _player.Speed = 1;
                Debug.Log("Player SlowDown");
                }
            else if(rnd == 2)
                {
                Destroy(_player.gameObject);
                Debug.Log("Player Destroed");
                }
            }

        public void Fly()
            {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
            }

        public void Rotation()
            {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
            }

        public void Clone()
            {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            }
        }
    }