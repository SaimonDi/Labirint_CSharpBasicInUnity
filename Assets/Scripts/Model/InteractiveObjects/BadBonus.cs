using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LabirintSpace
    {
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
        {
        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };
        private float _lengthFlay;
        private float _speedRotation;

        private void Awake()
            {
            _lengthFlay = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            }

        protected override void Interaction()
            {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            }

        public override void Execute()
            {
            if(!IsInteractable) { return; }
            Fly();
            Rotation();
            }

        public void Fly()
            {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
            }

        public void Rotation()
            {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
            }
        }


    }