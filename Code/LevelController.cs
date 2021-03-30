//using Code.Player;

//using Code.Player;
using UnityEngine;
using static UnityEngine.Debug;

namespace Code 
{
    internal sealed class LevelController : MonoBehaviour
    {
        #region Field

        private GameObject _player;
        private GameObject _groundCheckObject;
        private Rigidbody _rgPlayer;
        private Animator _animatorPlayer = null;
        private Transform _groundCheckTransform = null;
        private LayerMask _whatIsGround;

        #endregion
            
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            Log(_player.name);
            _rgPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
            Log(_rgPlayer.name);
            _animatorPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            Log(_animatorPlayer.name);
            _whatIsGround = LayerMask.GetMask("Ground");
            Log(_whatIsGround.value);
            _groundCheckObject = GameObject.FindGameObjectWithTag("GroundCheck");
            Log(_groundCheckObject.name);
        }

            
        void Update()
        {
            _groundCheckTransform = _groundCheckObject.transform;
            PlayerMovement.MovePlayer(_player, _rgPlayer, _animatorPlayer, _groundCheckTransform, _whatIsGround);
            
            //var playerMove = _player.GetComponent<Player.PlayerMovement>(); 
            // playerMove.MovePlayer(_player, _rgPlayer, _animatorPlayer, _groundCheckTransform, _whatIsGround);
        }
    }
}