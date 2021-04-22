using System.Collections.Generic;
using UnityEngine.UI;

namespace Code
{
    public interface IView
    {
        string FirstKeyText { get; }
        string FirstText { get; }
        void Display(string nameOfKey, int numbers, string message);
    }
}