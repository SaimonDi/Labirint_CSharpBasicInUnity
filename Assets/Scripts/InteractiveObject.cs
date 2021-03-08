using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LabirintSpace
    {
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
        {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
            {
            if(!IsInteractable||!other.CompareTag("Player"))
                {
                return;
                }
            Interaction();
            Destroy(gameObject);
            }

        private void Start()
            {
                Action();
            }

        public void Action()
            {
            if(TryGetComponent(out Renderer renderer))
                {
                renderer.material.color = Random.ColorHSV();
                }
            }

        public int CompareTo(InteractiveObject other)
            {
            return name.CompareTo(other.name);
            }

        }
    }