using System.Collections.Generic;
using UnityEngine.UI;

namespace Code.Interfaces
{
    public interface IView
    {
        void Display(int count, int numbers, InformationObjects _textLines, List<Text> _texts);
    }
}
