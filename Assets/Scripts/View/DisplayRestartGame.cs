using System;
using UnityEngine;
using UnityEngine.UI;

namespace LabirintSpace
    {
    public sealed class DisplayRestartGame 
        {
        private Text _restartButtonLabel;
        private Button _restartButton;
        public DisplayRestartGame(Button restartButton)
            {
            _restartButton = restartButton;
            RestartGameButton(false);
            }
        public void RestartGameButton(bool bollian)
            {
            _restartButton.gameObject.SetActive(bollian);
            _restartButtonLabel = _restartButton.GetComponentInChildren<Text>();
            _restartButtonLabel.text = "Перезапуск";
            }
        }
    }