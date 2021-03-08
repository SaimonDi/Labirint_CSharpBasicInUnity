using System.Collections;
using UnityEngine;
<<<<<<< Updated upstream
=======
using System;
using Random = UnityEngine.Random;
>>>>>>> Stashed changes

namespace LabirintSpace
    {
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
        {
        public int Point;
        public event Action<int> OnPointChange = delegate (int i) { };
        private Material _material;
<<<<<<< Updated upstream
        private float _lengthFly;
<<<<<<< Updated upstream:Assets/Scripts/GoodBonus.cs
        private DisplayBonuses _displayBonuses;
        private Player _player;
=======
>>>>>>> Stashed changes:Assets/Scripts/Model/InteractiveObjects/GoodBonus.cs
=======
        private float _lengthFlay;
>>>>>>> Stashed changes

        private void Awake()
            {
            _material = GetComponent<Renderer>().material;
<<<<<<< Updated upstream
            _lengthFly = Random.Range(1.0f, 5.0f);
            _player = FindObjectOfType<Player>();
=======
            _lengthFlay = Random.Range(1.0f, 5.0f);
>>>>>>> Stashed changes
            }

        protected override void Interaction()
            {
<<<<<<< Updated upstream
<<<<<<< Updated upstream:Assets/Scripts/GoodBonus.cs
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
=======
=======
>>>>>>> Stashed changes
            OnPointChange.Invoke(Point);
            }

        public override void Execute()
            {
            if(!IsInteractable) { return; }
            Fly();
            Flicker();
<<<<<<< Updated upstream
>>>>>>> Stashed changes:Assets/Scripts/Model/InteractiveObjects/GoodBonus.cs
=======
>>>>>>> Stashed changes
            }

        public void Fly()
            {
<<<<<<< Updated upstream
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly), transform.localPosition.z);
=======
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
>>>>>>> Stashed changes
            }

        public void Flicker()
            {
<<<<<<< Updated upstream
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
            }
        }
=======
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
            }
        }

>>>>>>> Stashed changes
    }