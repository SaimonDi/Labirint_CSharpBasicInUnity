<<<<<<< Updated upstream
﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
=======
﻿using System;
using UnityEngine;
using UnityEngine.UI;
>>>>>>> Stashed changes

namespace LabirintSpace
    {
    public sealed class DisplayBonuses
        {
        private Text _bonuseLable;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        public DisplayBonuses(GameObject bonus)
            {
            _bonuseLable = bonus.GetComponentInChildren<Text>();
            _bonuseLable.text = String.Empty;
            }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        public void Display(int value)
            {
            _bonuseLable.text = $"Вы набрали {value}";
            }
        }
    }