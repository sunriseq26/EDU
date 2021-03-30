using System;
using Code.Player;
using UnityEngine;

namespace Code.Objects
{
    public class EnemyMine : InteractiveObject, IEquatable<EnemyMine>
    {
        private PlayerHealth _playerHealth;
        protected override void Interaction()
        {
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            var hp = _playerHealth.HealthObject;
            var textLines = GameController._textLines;
            var _textsList = DisplayInfoOnScreen._texts;
            
            _view.Display(0, -hp, textLines, _textsList);
            
            _playerHealth.TakeDamage(hp);
        }

        public bool Equals(EnemyMine other)
        {
            return _playerHealth == other._playerHealth;
        }
    }
}