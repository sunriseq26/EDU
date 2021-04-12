using System;

namespace Code
{
    public interface IInteractiveObject
    {
        event Action<IInteractiveObject> OnTriggerEnterChange;
        void Initialization(IView view, IHealth health);
    }
}