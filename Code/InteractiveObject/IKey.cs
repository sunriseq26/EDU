using System;

namespace Code
{
    public interface IKey
    {
        //public int KeyCount { get; set; }
        event Action<int> AddKey;
    }
}