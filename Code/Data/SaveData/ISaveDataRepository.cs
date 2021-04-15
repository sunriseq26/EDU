using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public interface ISaveDataRepository
    {
        void Save(Transform player, List<EnemyProvider> enemies);
        void Load(Transform player, List<EnemyProvider> enemies);
    }
}