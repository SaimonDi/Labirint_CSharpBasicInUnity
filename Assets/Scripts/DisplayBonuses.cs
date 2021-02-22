using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LabirintSpace
    {
    public sealed class DisplayBonuses
        {
        private Text _text;
        public DisplayBonuses()
            {
            _text = Object.FindObjectOfType<Text>();
            }
        public void Display(int value)
            {
            _text.text = $"Вы набрали {value}";
            }
        }
    }