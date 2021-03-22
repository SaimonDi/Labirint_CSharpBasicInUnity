using System;
using System.Collections;
using UnityEngine;

namespace LabirintSpace
    {
    public static class Extensions 
        {
        public static bool TryBool(this string self) => Boolean.TryParse(self, out var res) && res;
        public static float TrySingle(this string self) => Single.TryParse(self, out var res) ? res : 0;

        }
    }