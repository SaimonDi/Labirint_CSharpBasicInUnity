using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

namespace LabirintSpace
    {
    public sealed class GameController : MonoBehaviour, IDisposable
        {
        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private DisplayWinGame _displayWinGame;
        private CameraController _cameraController;
        private InputController _inputController;
        private SaveAndLoadController _saveAndLoadController;
        private int _remainingBonuses;
        private int _countBonuses;
        private Reference _reference;

        private void Awake()
            {
            _interactiveObject = new ListExecuteObject();

            _reference = new Reference();

            PlayerBase player = null;
            if(PlayerType == PlayerType.Ball)
                {
                player = _reference.PlayerBall;
                }


            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            if(Application.platform == RuntimePlatform.WindowsEditor)
                {
                _inputController = new InputController(player);
                _interactiveObject.AddExecuteObject(_inputController);
                }


            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);
            _displayWinGame = new DisplayWinGame(_reference.EndGame);

            foreach(var o in _interactiveObject)
                {
                if(o is BadBonus badBonus)
                    {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                    }

                if(o is GoodBonus goodBonus)
                    {
                    goodBonus.OnPointChange += AddBonuse;
                    _remainingBonuses++;
                    }
                }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);

            _saveAndLoadController = new SaveAndLoadController(_interactiveObject, player);
            _interactiveObject.AddExecuteObject(_saveAndLoadController);
            }

        private void RestartGame()
            {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
            }

        private void CaughtPlayer(string value, Color args)
            {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            }

        private void AddBonuse(int value)
            {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
            WinGame();
            }
        private void WinGame()
            {
            _remainingBonuses--;
            if(_remainingBonuses == 0)
                {
                Time.timeScale = 0.0f;
                _displayWinGame.Display(_countBonuses);
                _reference.RestartButton.gameObject.SetActive(true);
                }
            else { return; }
            }

        private void Update()
            {
            for(var i = 0; i < _interactiveObject.Length; i++)
                {
                var interactiveObject = _interactiveObject[i];

                if(interactiveObject == null)
                    {
                    continue;
                    }
                interactiveObject.Execute();
                }
            }

        public void Dispose()
            {
            foreach(var o in _interactiveObject)
                {
                if(o is BadBonus badBonus)
                    {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                    }

                if(o is GoodBonus goodBonus)
                    {
                    goodBonus.OnPointChange -= AddBonuse;
                    }
                }
            }
        }
    }