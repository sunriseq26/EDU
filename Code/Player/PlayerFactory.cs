using UnityEngine;

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
            return new GameObject("player").AddUnit(_playerData).
                AddRigidbody(_playerData.Mass, _playerData.AngularDrag, _playerData.IsGravity, _playerData.IsFreeze).transform;
        }
    }
}