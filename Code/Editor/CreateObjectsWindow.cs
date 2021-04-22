using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Code
{
    public class CreateObjectsWindow : EditorWindow
    {
        public static GameObject _intstantiateGameObject;
        public string _nameObject = "Введите текст";
        public bool _groupEnabled;
        public Vector3 _manualEnter;
        public Transform _transformOfObject;

        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            _intstantiateGameObject =
                EditorGUILayout.ObjectField("Объект который хотим вставить",
                        _intstantiateGameObject, typeof(GameObject), true)
                    as GameObject;
            _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
            _groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
                _groupEnabled);
            _transformOfObject = EditorGUILayout.ObjectField("Перетащить Transform объекта",
                    _transformOfObject, typeof(Transform), true) 
                as Transform;
            _manualEnter = EditorGUILayout.Vector3Field("Иначе ввести координаты вручную ", 
                                                        _manualEnter);
            EditorGUILayout.EndToggleGroup();
            var button = GUILayout.Button("Создать объекты");

            if (button)
            {
                if (!_groupEnabled)
                {
                    GameObject temp = Instantiate(_intstantiateGameObject);
                    
                    temp.name = _intstantiateGameObject.name;
                }

                if (_groupEnabled && _transformOfObject != null)
                {
                    GameObject temp = Instantiate(_intstantiateGameObject, _transformOfObject.position, _transformOfObject.rotation);
                    temp.name = _intstantiateGameObject.name;
                }
                if (_groupEnabled && _transformOfObject == null)
                {
                    GameObject temp = Instantiate(_intstantiateGameObject, _manualEnter, Quaternion.identity);
                    temp.name = _intstantiateGameObject.name;
                }
            }
        }
    }
}