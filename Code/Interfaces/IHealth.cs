namespace Code
{
    public interface IHealth
    {
        int PlayerHealth { get; set; }
        
        void TakeDamage(int damage);
        void ReplenishHealth(int healthUnit);
        void Die();
    }
}