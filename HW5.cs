using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public sealed class HW5 : MonoBehaviour
    {
        private void Awake()
        {
            Task4();
        }

        #region Task2

        private void FindNumberCharFor(string message, char i)
        {
            var result = 0;
            for (int j = 0; j < message.Length; j++)
            {
                if (j == i)
                {
                    result++;
                }
            }
            Debug.Log(result);
        }
        
        private void FindNumberCharIndexOf(string message, char i)
        {
            var result = message.IndexOf(i);
            Debug.Log(result);
        }

        #endregion

        
        #region Task3

        public void FindCountItemsInt(List<int> num)
        {
            List<int> numbers = num;

            foreach (var number in numbers)
            {
                var result = numbers.IndexOf(number);
                Debug.Log(result);
            }
        }
        
        public void FindCountItems<T>(List<T> list)
        {
            foreach (var tList in list)
            {
                var result = list.IndexOf(tList);
                Debug.Log(result);
            }
        }
        
        public void FindCountItemsLinq<T>(List<T> list)
        {
            var count = 0;
            var result = list.Where(tList => list.IndexOf(tList) == count++);
            Debug.Log(result);
        }

        #endregion
        
        
        #region Task4

        
        public void Task4()
        {
            
            
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });

            var c = dict.OrderBy(unit => unit.Value);
            
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
            
            foreach (var pair in c)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }

        #endregion
        
    }
}