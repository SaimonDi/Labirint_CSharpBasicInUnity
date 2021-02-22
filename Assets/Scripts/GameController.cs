using System.Collections;
using UnityEngine;

namespace LabirintSpace
    {
    public sealed class GameController : MonoBehaviour, IDisposable
        {
        private InteractiveObject[] _interactiveObjects;
        private void Awake()
            {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            }
        void Update()
            {
            for(int i = 0; i < _interactiveObjects.Length; i++)
                {
                var interactiveObject = _interactiveObjects[i];

                if(interactiveObject == null)
                    continue;
                if(interactiveObject is IFly fly)
                    fly.Fly();
                if(interactiveObject is IFlicker flicker)
                    flicker.Flicker();
                if(interactiveObject is IRotation rotation)
                    rotation.Rotation();
                }
            }
        public void Dispose()
            {
            foreach(var o in _interactiveObjects)
                {
                Destroy(o.gameObject);
                }
            }
        }
    }