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
        private ListExcecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private DisplayRestartGame _displayRestartGame;
        private DisplayWinGame _displayWinGame;
        private CameraController _cameraController;
        private InputController _inputController;
        private Button _buttonRestartGame;
        private int _countBonuses;
        private int _remainingBonuses;
        private Reference _reference;

        private void Awake()
            {
            _interactiveObject = new ListExcecuteObject();

            _reference = new Reference();

            _cameraController = new CameraController(_reference.PlayerBall.transform, _reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(_reference.PlayerBall);
            _interactiveObject.AddExecuteObject(_inputController);

            _buttonRestartGame = _reference.RestartButton;
            _buttonRestartGame.onClick.AddListener(RestartGame);

            _displayRestartGame = new DisplayRestartGame(_buttonRestartGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
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
            }

        private void RestartGame()
            {
            SceneManager.LoadScene(sceneBuildIndex:0);
            Time.timeScale = 1.0f;
            }

        private void CaughtPlayer(string value, Color args)
            {
            Time.timeScale = 0.0f;
            _displayRestartGame.RestartGameButton(true);
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
                _displayRestartGame.RestartGameButton(true);
                }
            else { return; }
            }

        void Update()
            {
            for(int i = 0; i < _interactiveObject.Length; i++)
                {
                var interactiveObject = _interactiveObject[i];

                if(interactiveObject == null)
                    continue;
                
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