using System;
using Code.Player;
using UnityEngine;

namespace Code.Objects
{
    public class EnemyMine : InteractiveObject, IEquatable<EnemyMine>
    {
        internal int Amount { get; set; } = 80;
        private PlayerHealth _playerHealth;
        public event Action<EventCamera> _onInteractionCamera;
        protected override void Interaction()
        {
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            var hp = _playerHealth.HealthObject;
            var textLines = GameController._textLines;
            var _textsList = DisplayInfoOnScreen._texts;
            
            _view.Display(0, -Amount, textLines, _textsList);
            
            _playerHealth.TakeDamage(Amount);
            
            _onInteractionCamera?.Invoke(new EventCamera());
        }

        public bool Equals(EnemyMine other)
        {
            return _playerHealth == other._playerHealth;
        }
    }
}