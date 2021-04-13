using System;

namespace Code
{
    public interface IAlive
    {
        bool IsAlive { get; set; }
        bool Die();
    }
}