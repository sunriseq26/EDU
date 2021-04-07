﻿using UnityEngine;

namespace Code
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public Transform CreatePlayer()
        {
            return new GameObject("player").
                AddSprite(_playerData.Sprite).AddCircleCollider2D().
                AddCircleCollider2D().AddTrailRenderer().transform;
        }
    }
}