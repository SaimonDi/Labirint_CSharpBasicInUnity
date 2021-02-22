using System.Collections;
using UnityEngine;

namespace LabirintSpace
    {
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker, ICloneable
        {
        private Material _material;
        private float _lengthFly;
        private DisplayBonuses _displayBonuses;
        private Player _player;

        private void Awake()
            {
            _displayBonuses = new DisplayBonuses();
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 5.0f);
            _player = FindObjectOfType<Player>();
            }
        protected override void Interaction()
            {
            _displayBonuses.Display(5);
            //add bonus
            AddGoodBonus();
            }

        private void AddGoodBonus()
            {
            var rnd = Random.Range(1, 2);
            if(rnd == 1)
                {
                _player.Speed = 10;
                Debug.Log("Player SpeedUp");
                }
            else if(rnd == 2)
                {
                _player.immortal = true;
                Debug.Log("Player Immortal");
                }
            }

        public void Fly()
            {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
            }

        public void Flicker()
            {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
            }

        public void Clone()
            {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            }
        }
    }