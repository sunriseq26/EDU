using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code
{
    public class SaveDataController : IController, IExecute
    {
        
        private readonly Transform _player;
        private readonly List<EnemyProvider> _enemies;
        private readonly ISaveDataRepository _saveDataRepository;
        private readonly List<InteriorDoor> _interiorDoors;
        //private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        private bool OnLoadBool = false;
        
        
        public SaveDataController(Transform player)
        {
            _player = player;
            _enemies = GameObject.FindObjectsOfType<EnemyProvider>().ToList();
            _saveDataRepository = new SaveDataRepository();
            _interiorDoors = Object.FindObjectsOfType<InteriorDoor>().ToList();
            foreach (var objectProvider in _interiorDoors)
            {
                objectProvider.OnSave += OnLoad;
            }
        }

        private void OnLoad(bool obj)
        {
            OnLoadBool = obj;
        }


        public void Execute(float deltaTime)
        {
            
            if (OnLoadBool)
            {
                _saveDataRepository.Save(_player, _enemies);
                OnLoadBool = false;
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_player, _enemies);
            }
        }
    }
}