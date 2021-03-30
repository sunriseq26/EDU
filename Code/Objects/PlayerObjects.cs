using System.Collections.Generic;
using Code.Interfaces;
using static UnityEngine.Debug;

namespace Code.Objects
{
    public class PlayerObjects //: IView
    {
        #region Field

        internal Dictionary<string, int> _itemsAndAmmunitions;

        #endregion

        public PlayerObjects()
        {
            _itemsAndAmmunitions = new Dictionary<string, int>();
        }
        
        #region Methods

        public void RaiseObjects(string objectName, int count)
        {
            int item = _itemsAndAmmunitions[objectName] + count;
            _itemsAndAmmunitions[objectName] = item;
            Log("Item: " + _itemsAndAmmunitions[objectName]);
        }

        public void TakeObjects(string objectName, int count)
        {
            int item = _itemsAndAmmunitions[objectName] - count;
            _itemsAndAmmunitions[objectName] = item;
            Log("Item: " + _itemsAndAmmunitions[objectName]);
        }

        public int NumberOfObjects(string objectName)
        {
            return _itemsAndAmmunitions[objectName];
        }

        #endregion

        
    }
}