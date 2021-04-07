namespace Code
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyType type);
    }
}