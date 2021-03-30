using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Code.Interfaces;
//using static UnityEngine.Debug;

namespace Code
{
    public class DisplayInfoOnScreen : IView
    {
        internal static List<Text> _texts;
        private IView _viewImplementation;

        public DisplayInfoOnScreen()
        {
            _texts = Object.FindObjectsOfType<Text>().ToList();
        }
        
        public void Display(int count, int numbers, InformationObjects _textLines, List<Text> _texts)
        {
            _textLines[count].CountField += numbers;
            _texts[count].text = $"{_textLines[count].TextField} {_textLines[count].CountField}";
        }
        
    }

    
}