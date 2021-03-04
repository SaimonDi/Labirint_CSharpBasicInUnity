using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

namespace LabirintSpace
    {
    public sealed class GameController : MonoBehaviour, IDisposable
        {
        public Text _finishGameLabel;
        private ListInteractableObject _interactiveObject;
        private DisplayEndGame _displayEndGame;

        private Player _player;
        private Color _playerMainColor;

        private void Awake()
            {
            _interactiveObject = new ListInteractableObject();
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            _player = FindObjectOfType<Player>();
            _playerMainColor = new Color
                (
                _player.GetComponent<Renderer>().material.color.r,
                _player.GetComponent<Renderer>().material.color.g, 
                _player.GetComponent<Renderer>().material.color.b
                );

            foreach(var o in _interactiveObject)
                {
                if(o is BadBonus badBonus)
                    {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                    }
                if(o is GoodBonus goodBonus)
                    {
                    goodBonus.CaughtPlayerBonus += CaughtPlayerBonus;
                    }
                }
            }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
            {
            Time.timeScale = 0.0f;
            }
        private void CaughtPlayerBonus(object value, CaughtPlayerEventArgs args)
            {
            var rnd = Random.Range(1, 100);
            if(rnd % 2 == 0)
                {
                _player.PlayerSpeedUp(true,args.Color);
                Debug.Log("Player SpeedUp");
                Invoke("ResetSpeed", 7f);
                }
            else if(rnd % 2 == 1)
                {
                _player.PlayerImmortal(true);
                Debug.Log("Player Immortal");
                Invoke("ResetImmortal", 7f);
                }
            }
        void ResetSpeed() => _player.PlayerSpeedUp(false, _playerMainColor);
        void ResetImmortal() => _player.PlayerImmortal(false);


        void Update()
            {
            for(int i = 0; i < _interactiveObject.Count; i++)
                {
                var interactiveObject = _interactiveObject[i];

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
            foreach(var o in _interactiveObject)
                {
                if(o is InteractiveObject interactiveObject)
                    {
                    if(o is BadBonus badBonus)
                        {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                        }
                    Destroy(interactiveObject.gameObject);
                    }
                }
            }
        }
    }