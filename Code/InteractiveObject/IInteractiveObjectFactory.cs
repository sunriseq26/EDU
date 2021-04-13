namespace Code
{
    public interface IInteractiveObjectFactory
    {
        public InteractiveObjectData Data { get; }

        IInteractiveObject CreateInteractiveObject(InteractiveObjectType type);
    }
}