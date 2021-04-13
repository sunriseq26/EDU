using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "UnitHealthSettings", menuName = "Data/Unit/UnitHealthSettings")]
    public class PlayerDataHealth : ScriptableObject
    {
        [SerializeField, Range(0, 100)]private int _maximumValueHealth;
        [SerializeField, Range(0, 500)]private int _valueHealth;
        
        public int MaximumValueHealth => _maximumValueHealth;
        public int ValueHealth => _valueHealth;
    }
}