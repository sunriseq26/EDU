using System;
using Code.Player;
using UnityEngine;

namespace Code.Objects
{
    public class AidKit : InteractiveObject, IEquatable<AidKit>
    {
        internal int Amount { get; set; } = 50;
        
        protected override void Interaction()
        {
            var textLines = GameController._textLines;
            var _textsList = DisplayInfoOnScreen._texts;
            _view.Display(0, Amount, textLines, _textsList);
            
            var playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            playerHealth.ReplenishHealth(Amount);
            
        }

        public bool Equals(AidKit other)
        {
            return Amount == other.Amount;
        }
    }
}