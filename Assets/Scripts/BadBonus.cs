using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LabirintSpace
    {
    public sealed class BadBonus : InteractiveObject, IFly, IRotation, ICloneable
        {
        private float _lengthFly;
        private float _speedRotation;
        
        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
            { 
            add { _caughtPlayer += value; } 
            remove { _caughtPlayer -= value; }
            }

        private void Awake()
            {
            _lengthFly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            }
        protected override void Interaction()
            {
            _caughtPlayer?.Invoke( this, new CaughtPlayerEventArgs(_color));
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