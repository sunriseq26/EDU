namespace Asteroids
{
    public interface IDamage
    {
        float HealthUnit { get; set; }
        void TakeDamage(float damage);
    }
}