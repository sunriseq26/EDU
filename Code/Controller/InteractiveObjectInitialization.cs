using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class InteractiveObjectInitialization : IInitialization
    {
        //protected IView _view;
        private readonly IInteractiveObjectFactory _interactiveObjectFactory;
        private readonly InteractiveObjectData _data;
        private List<IInteractiveObject> _interactiveObjects;

        public InteractiveObjectInitialization(IInteractiveObjectFactory interactiveObjectFactory, IView view, IHealth health, InteractiveObjectData interactiveObjectData)
        {
            _interactiveObjectFactory = interactiveObjectFactory;
            _data = _interactiveObjectFactory.Data;
            interactiveObjectData.KeyCount = 0;
            Debug.Log($"Current Keys: {interactiveObjectData.KeyCount}");
            _interactiveObjects = new List<IInteractiveObject>();
            foreach (var dataListInteractiveObjectInfo in _data.ListInteractiveObjectInfos)
            {
                var interactiveObject =
                    _interactiveObjectFactory.CreateInteractiveObject(dataListInteractiveObjectInfo.Type);
                interactiveObject.Initialization(view, health, interactiveObjectData);
                interactiveObject.OnTriggerEnterChange += InteractiveObjectOnDestroyChange;
                _interactiveObjects.Add(interactiveObject);
                Debug.Log(interactiveObject);
            }

            // foreach (var interactiveObject in _interactiveObjects)
            // {
            //     interactiveObject.Initialization(view);
            //     interactiveObject.OnTriggerEnterChange += InteractiveObjectOnDestroyChange;
            // }
        }

        private void InteractiveObjectOnDestroyChange(IInteractiveObject value)
        {
            value.OnTriggerEnterChange -= InteractiveObjectOnDestroyChange;
            _interactiveObjects.Remove(value);
        }
        
        public IEnumerable<IInteractiveObject> GetInteractiveObject()
        {
            foreach (var interactiveObject in _interactiveObjects)
            {
                yield return interactiveObject;
            }
        }

        public void Initialization()
        {
        }
    }
}