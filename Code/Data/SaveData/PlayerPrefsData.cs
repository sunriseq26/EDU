using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class PlayerPrefsData : IData<SavedData>
    {
        public void Save(List<SavedData> data, string path = null)
        {
            PlayerPrefs.SetString("Name", data[0].Name);
            PlayerPrefs.SetFloat("PosX", data[0].Position.X);
            PlayerPrefs.SetFloat("PosY", data[0].Position.Y);
            PlayerPrefs.SetFloat("PosZ", data[0].Position.Z);
            PlayerPrefs.SetString("IsEnable", data[0].IsEnabled.ToString());

            //-----------------------------
            PlayerPrefs.Save();
        }

        public List<SavedData> Load(string path = null)
        {
            var result = new List<SavedData>();

            // var key = "Name";
            // if (PlayerPrefs.HasKey(key))
            // {
            //     result.Name = PlayerPrefs.GetString(key);
            // }
            //
            // key = "PosX";
            // if (PlayerPrefs.HasKey(key))
            // {
            //     result.Position.X = PlayerPrefs.GetFloat(key);
            // }
            //
            // key = "PosY";
            // if (PlayerPrefs.HasKey(key))
            // {
            //     result.Position.Y= PlayerPrefs.GetFloat(key);
            // }
            //
            // key = "PosZ";
            // if (PlayerPrefs.HasKey(key))
            // {
            //     result.Position.Z = PlayerPrefs.GetFloat(key);
            // }
            //
            // key = "IsEnable";
            // if (PlayerPrefs.HasKey(key))
            // {
            //     result.IsEnabled = PlayerPrefs.GetString(key).TryBool();
            // }
            return result;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}