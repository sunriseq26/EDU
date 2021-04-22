namespace Code
{
    public interface IInteractable : IInitialization
    {
        bool IsInteractable { get; }
    }
}