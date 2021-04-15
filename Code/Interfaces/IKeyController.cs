using System;

namespace Code
{
    public interface IKeyController
    {
        event Action<int> Keys;
    }
}