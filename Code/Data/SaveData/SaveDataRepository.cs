using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

namespace Code
{
    public sealed class SaveDataRepository : ISaveDataRepository 
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
            
        }

        public void Save(Transform player, List<EnemyProvider> enemies)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            List<SavedData> arrayStrings = new List<SavedData>();
            var namePlayer = player.name;
            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                Name = namePlayer,
                IsEnabled = true
            };
            arrayStrings.Add(savePlayer);
            
            foreach (var enemy in enemies)
            {
                var nameEnemy = enemy.name;
                var saveEnemy = new SavedData
                {
                    Position = enemy.transform.position,
                    Name = nameEnemy,
                    IsEnabled = true
                };
                arrayStrings.Add(saveEnemy);
            }

            Debug.Log("<color=red>Save</color>");
            _data.Save(arrayStrings, Path.Combine(_path, _fileName));
        }

        public void Load(Transform player, List<EnemyProvider> enemies)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            int count = 0;
            var newElements = _data.Load(file);
            Debug.Log(newElements.Count);
            Debug.Log(enemies.Count);
            player.transform.position = newElements[count].Position;
            player.name = newElements[count].Name;
            player.gameObject.SetActive(newElements[count].IsEnabled);
            count = 1;
            
            for (int i = count; i < newElements.Count; i++)
            {
                Debug.Log(i);
                enemies[i-count].transform.position = newElements[i].Position;
                enemies[i-count].name = newElements[i].Name;
                enemies[i-count].gameObject.SetActive(newElements[i].IsEnabled);
            }
            count += enemies.Count;

            Debug.Log(count);
        }
    }
}