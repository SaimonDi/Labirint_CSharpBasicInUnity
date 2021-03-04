using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LabirintSpace
    {
    public abstract class InteractiveObject : MonoBehaviour, IExecute
        {
<<<<<<< Updated upstream:Assets/Scripts/InteractiveObject.cs
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();
=======
        protected Color _color;
        private bool _isInteractable;

        protected bool IsInteractable
            {
            get { return _isInteractable; }
            private set
                {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
                }
            }
>>>>>>> Stashed changes:Assets/Scripts/Model/InteractiveObjects/InteractiveObject.cs

        private void OnTriggerEnter(Collider other)
            {
            if(!IsInteractable||!other.CompareTag("Player"))
                {
                return;
                }
            Interaction();
            IsInteractable = false;
            }
<<<<<<< Updated upstream:Assets/Scripts/InteractiveObject.cs

        private void Start()
            {
                Action();
            }

        public void Action()
            {
=======

        protected abstract void Interaction();
        public abstract void Execute();

        private void Start()
            {
            IsInteractable = true;
            _color = Random.ColorHSV();
>>>>>>> Stashed changes:Assets/Scripts/Model/InteractiveObjects/InteractiveObject.cs
            if(TryGetComponent(out Renderer renderer))
                {
                renderer.material.color = Random.ColorHSV();
                }
            }
        }
    }