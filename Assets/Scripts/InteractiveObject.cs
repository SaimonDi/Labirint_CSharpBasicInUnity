using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LabirintSpace
    {
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
        {
        protected Color _color;
        public bool IsInteractable { get; } = true;

        private void OnTriggerEnter(Collider other)
            {
            if(!IsInteractable||!other.CompareTag("Player"))
                {
                return;
                }
            Interaction();
            Destroy(gameObject);
            }
        protected abstract void Interaction();

        private void Start()
            {
                Action();
            }

        public void Action()
            {
            _color = Random.ColorHSV();
            if(TryGetComponent(out Renderer renderer))
                {
                renderer.material.color = _color;
                }
            }

        public int CompareTo(InteractiveObject other)
            {
            return name.CompareTo(other.name);
            }

        }
    }