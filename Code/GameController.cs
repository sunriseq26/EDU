using System;
using System.Collections.Generic;
using UnityEngine;
using Code.Player;
using UnityEngine.UI;
using System.Linq;
using static Code.Player.PlayerMovement;
using Code.Objects;
using static UnityEngine.Debug;

namespace Code 
{
    internal sealed class GameController : MonoBehaviour
    {
        #region Field

        #region Player and Move

        private GameObject _player;
        private GameObject _groundCheckObject;
        private Rigidbody _rgPlayer;
        private Animator _animatorPlayer;
        private Transform _groundCheckTransform;
        private LayerMask _whatIsGround;

        #endregion
        

        #region Player Objects

        internal static PlayerObjects _playerObjects;
        private List<InteractiveObject> _interactiveObjects;
        internal static List<Text> Texts { get; set; }
        internal static InformationObjects _textLines;
        private Animator _door;
        private DoorController _doorController;

        #endregion
        
        
        #region Player Status

        private bool _playerIsAlive;
        private int _playerHealth;
        private int _bullets = 50;
        private int _mines = 5;
        private int _keys = 0;

        #endregion

        #endregion


        #region UnityMethods
        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerHealth = _player.GetComponent<PlayerHealth>().HealthObject;
            _rgPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
            _animatorPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            _whatIsGround = LayerMask.GetMask("Ground");
            _groundCheckObject = GameObject.FindGameObjectWithTag("GroundCheck");
            _playerIsAlive = _player.GetComponent<PlayerHealth>().IsAlive;
            Log("Player IsAlive = " + _playerIsAlive);
            
            _playerIsAlive = true;
            Log("Player IsAlive = " + _playerIsAlive + ". Player Health: " + _playerHealth);
            
            // _bullets = GameObject.FindGameObjectWithTag("Ammunitions").GetComponent<Ammunitions>().Amount;
            // _bullets = 60;
            
            // _playerObjects = new PlayerObjects();
            // var items = _playerObjects._itemsAndAmmunitions;
            // items.Add("health", _playerHealth);
            // items.Add("bullets", _bullets);
            // items.Add("mines", _mines);
            // items.Add("blueKeys", _keys);

            _textLines = new InformationObjects();
            _textLines[0] = new InformationObject{TextField = "Health: ", CountField = _playerHealth};
            _textLines[1] = new InformationObject{TextField = "Bullets: ", CountField = _bullets};
            _textLines[2] = new InformationObject{TextField = "Mines: ", CountField = _bullets};
            _textLines[3] = new InformationObject{TextField = "Keys: ", CountField = _keys};
            
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            var _displayInfoOnScreen = new DisplayInfoOnScreen();
            foreach (var interactiveObject in _interactiveObjects)
            {
                interactiveObject.Initialization(_displayInfoOnScreen);
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyChange;
            }

            var _textsList = DisplayInfoOnScreen._texts;
            StartDisplay(_textLines, _textsList);

            var addComponent = FindObjectOfType<EnemyMine>();
            addComponent._onInteractionCamera += (n) =>
            {
                var eventCamera = new EventCamera();
                eventCamera.EventCameraLog();
            };
        }
        
        
        void Update()
        {
            _groundCheckTransform = _groundCheckObject.transform;
            MovePlayer(_player, _rgPlayer, _animatorPlayer, _groundCheckTransform, _whatIsGround);
        }
        
        
        #endregion


        #region Methods

        private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        {
            value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
            _interactiveObjects.Remove(value);
        }

        public void StartDisplay(InformationObjects _textLines, List<Text> _texts)
        {
            for (int i = 0; i < _texts.Count; i++)
            {
                _texts[i].text = $"{_textLines[i].TextField} {_textLines[i].CountField}";
                Log(_texts[i].text);
            }
        }
        
        #endregion
        
    }
}