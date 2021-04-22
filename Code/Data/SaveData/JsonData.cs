using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Code
{
    public class JsonData<T> : IData<T>
    {
        public void Save(List<T> data, string path = null)
        {
            List<string> stringPoint = new List<string>();
            foreach (var item in data)
            {
                var str = JsonUtility.ToJson(item);
                stringPoint.Add(str);
            }
            // File.WriteAllText(path, Crypto.CryptoXOR(str));
            File.WriteAllLines(path, stringPoint);
            
            foreach (var item in data)
            {
                
            }
        }

        public List<T> Load(string path = null)
        {
            var str = File.ReadAllLines(path);
            var objects = new List<T>();
            // return JsonUtility.FromJson<T>(Crypto.CryptoXOR(str));
            foreach (var s in str)
            {
                objects.Add(JsonUtility.FromJson<T>(s));
            }
            return objects;
        }
    }
}