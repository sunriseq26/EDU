namespace Asteroids
{
    public sealed class Health : IDamage
    {
        public float HealthUnit { get; set; }
        public float Max { get; }
        public float Current { get; private set; }
        
        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
        public void TakeDamage(float damage)
        {
            Current -= damage;
        }
    }
}
