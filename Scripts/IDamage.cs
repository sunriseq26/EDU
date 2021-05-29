namespace Asteroids
{
    public interface IDamage
    {
        float Health { get; set; }
        void TakeDamage(int damage);
        void ReplenishHealth(int healthUnit);
    }
}