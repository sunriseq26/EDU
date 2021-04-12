using System;
using UnityEngine;

namespace Code
{
    public interface IEnemy : IMove
    {
        event Action<int> OnTriggerEnterChange;
    }
}