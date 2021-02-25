using System.Collections;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace LabirintSpace
    {
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker, ICloneable
        {
        public int Point;
        private Material _material;
        private float _lengthFly;
        private DisplayBonuses _displayBonuses;

        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayerBonus;
        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayerBonus
            {
            add { _caughtPlayerBonus += value; }
            remove { _caughtPlayerBonus -= value; }
            }

        private void Awake()
            {
            _displayBonuses = new DisplayBonuses();
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 5.0f);
            }
        protected override void Interaction()
            {
            //_displayBonuses.Display(5);
            //add bonus
            _caughtPlayerBonus?.Invoke(this, new CaughtPlayerEventArgs(_color));
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