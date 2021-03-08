using System;
using UnityEngine;
using UnityEngine.UI;

namespace LabirintSpace
    {
    public sealed class DisplayEndGame
        {
        private Text _finishGameLabel;
<<<<<<< Updated upstream:Assets/Scripts/View/DisplayEndGame.cs
=======

>>>>>>> Stashed changes:Assets/Scripts/DisplayEndGame.cs
        public DisplayEndGame(GameObject endGame)
            {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
            }
<<<<<<< Updated upstream:Assets/Scripts/View/DisplayEndGame.cs
=======

>>>>>>> Stashed changes:Assets/Scripts/DisplayEndGame.cs
        public void GameOver(string name, Color color)
            {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {name} {color} цвета";
            }
        }
    }