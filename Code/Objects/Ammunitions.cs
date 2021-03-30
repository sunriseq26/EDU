using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Code.Interfaces;

namespace Code
{
    public class Ammunitions : InteractiveObject, IEquatable<Ammunitions>
    {
        internal int Amount { get; set; } = 30;
        
        protected override void Interaction()
        {
            var textLines = GameController._textLines;
            var _textsList = DisplayInfoOnScreen._texts;
            _view.Display(1, Amount, textLines, _textsList);
            // Add bonus
        }

        public bool Equals(Ammunitions other)
        {
            return Amount == other.Amount;
        }
    }
}