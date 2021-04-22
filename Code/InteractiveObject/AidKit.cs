using System;
using UnityEngine;

namespace Code
{
    public class AidKit : InteractiveObjectProvider, IEquatable<AidKit>
    {
        internal int Amount { get; set; } = 50;
        
        protected override void Interaction()
        {
            // var textLines = GetComponent<InformationObjects>();
            // var _textsList = GetComponent<DisplayInfo>().Text;

            // var player = GameObject.FindGameObjectWithTag("Player");
            // var playerHealth = player.GetComponent<IHealth>();
            //var displayInfo = player.GetComponent<IDisplay>();
            var displayInfoFirstKeyText = _view.FirstKeyText;
            var displayInfoFistText = _view.FirstText;
            _health.ReplenishHealth(Amount);
            _view.Display(displayInfoFirstKeyText, _health.PlayerHealth, displayInfoFistText);
            
        }

        public bool Equals(AidKit other)
        {
            return Amount == other.Amount;
        }
    }
}