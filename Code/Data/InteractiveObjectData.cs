using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "InteractiveObjectSettings", menuName = "Data/Unit/InteractiveObjectSettings")]
    public sealed class InteractiveObjectData : ScriptableObject
    {
        [Serializable] 
        public struct InteractiveObjectInfo
        {
            public InteractiveObjectType Type;
            public InteractiveObjectProvider InteractiveObjectPrefab;
            public Transform _position;
        }

        [SerializeField] private List<InteractiveObjectInfo> _interactiveObjectInfos;

        public List<InteractiveObjectInfo> ListInteractiveObjectInfos => _interactiveObjectInfos;

        public InteractiveObjectProvider GetInteractiveObject(InteractiveObjectType type)
        {
            var interactiveObjectInfo = _interactiveObjectInfos.First(info => info.Type == type);
            return interactiveObjectInfo.InteractiveObjectPrefab;
        }
    }
}