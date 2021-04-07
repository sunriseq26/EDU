using System;

namespace Code
{
    public interface IEnemy : IMove
    {
        event Action<int> OnTriggerEnterChange;
    }
}