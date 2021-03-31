using System;
using UnityEngine;

namespace Code
{
    public sealed class GameException : Exception
    {
        public GameException(float value) 
        {
            Debug.LogWarning($"Значение превышает {value}");
        }
    }
}