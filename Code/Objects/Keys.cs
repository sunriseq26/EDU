using System;
using static UnityEngine.Debug;

namespace Code.Objects
{
    public class Keys : InteractiveObject, IEquatable<Keys>
    {
        internal int Amount { get; set; } = 1;
        
        protected override void Interaction()
        {
            var textLines = GameController._textLines;
            textLines[3].CountField += Amount;
            Log(textLines[3].CountField);
            // Add bonus
        }

        public bool Equals(Keys other)
        {
            return Amount == other.Amount;
        }
    }
}