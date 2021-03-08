using System.Collections;
using UnityEngine;

namespace LabirintSpace
    {
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
        {
        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };
        private float _lengthFly;
        private float _speedRotation;
<<<<<<< Updated upstream:Assets/Scripts/BadBonus.cs
        private Player _player;


=======
        
>>>>>>> Stashed changes:Assets/Scripts/Model/InteractiveObjects/BadBonus.cs
        private void Awake()
            {
            _lengthFly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            _player = FindObjectOfType<Player>();
            }
        protected override void Interaction()
            {
<<<<<<< Updated upstream:Assets/Scripts/BadBonus.cs
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
=======
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            }

        public override void Execute()
            {
            if(!IsInteractable) { return; }
            Fly();
            Rotation();
>>>>>>> Stashed changes:Assets/Scripts/Model/InteractiveObjects/BadBonus.cs
            }

        public void Fly()
            {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
            }

        public void Rotation()
            {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
            }
        }
    }