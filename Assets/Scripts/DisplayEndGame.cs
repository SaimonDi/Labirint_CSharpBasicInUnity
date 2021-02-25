using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace LabirintSpace
    {
    public sealed class DisplayEndGame
        {
        private Text _finishGameLabel;
        public DisplayEndGame(Text finishGameLabel)
            {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = String.Empty;
            }

        public void GameOver(object o, CaughtPlayerEventArgs args)
            {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {o} {args.Color} цвета";
            }
        }
    }