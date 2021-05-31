namespace Asteroids
{
    public interface IDamage
    {
        float Health { get; set; }
        float Damage { get; }
        void TakeDamage(float damage);
        void ReplenishHealth(float healthUnit);
    }
}