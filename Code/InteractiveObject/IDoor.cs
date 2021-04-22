using System;

namespace Code
{
    public interface IDoor
    {
        event Action<bool> OpenDoor; 
    }
}