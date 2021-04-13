using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Data/Unit/EnemySettings")]
    public sealed class EnemyData : ScriptableObject
    {
        [Serializable] 
        public struct EnemyInfo
        {
            public EnemyType Type;
            public EnemyProvider EnemyPrefab;
        }

        [SerializeField] private List<EnemyInfo> _enemyInfos;

        public List<EnemyInfo> ListEnemyInfos => _enemyInfos;

        public EnemyProvider GetEnemy(EnemyType type)
        {
            var enemyInfo = _enemyInfos.First(info => info.Type == type);
            return enemyInfo.EnemyPrefab;
        }
    }
}