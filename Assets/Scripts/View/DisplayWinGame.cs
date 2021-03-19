using System;
using UnityEngine;
using UnityEngine.UI;

namespace LabirintSpace
    {
    public sealed class DisplayWinGame 
        {
        private Text _finishGameLabel;
        public DisplayWinGame(GameObject winGame)
            {
            _finishGameLabel = winGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
            }
        public void Display(int value)
            {
            _finishGameLabel.text = $"Вы выйграли. Вы набрали {value} очков";
            }
        }
    }