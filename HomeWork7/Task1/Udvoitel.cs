//Кустарников Иван

//а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
//б) Добавить меню и команду «Играть». При нажатии появляется сообщение, 
//какое число должен получить игрок.Игрок должен постараться получить это число за минимальное количество ходов.
//в) * Добавить кнопку «Отменить», которая отменяет последние ходы.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RMI_Stavropol
{
    enum GameState
    {
        More, Less, Win
    }


    class Udvoitel
    {

        public int Target { get; private set; }
        public int Current { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }

        public Udvoitel(int Target)
        {
            this.Target = Target;
            Current = 1;
            Count = 0;
            MaxCount = 0;
        }

        public void Plus()
        {
            Current++;
            Count++;
        }

        public void Multi()
        {
            Current *= 2;
            Count++;
        }

        public void Reset()
        {
            Current = 1;
            Count = 0;
        }

        public void Back(string msg)
        {
            if (msg == "Minus")
            {
                Current -= 1;
                Count--;
            }
            if (msg == "Delete")
            {
                Current /= 2;
                Count--;
            }

        }

        public GameState Check()
        {
            if (Current == Target) return GameState.Win;
            if (Current < Target)
                return GameState.Less;
            else
                return GameState.More;

        }

        public bool CountTry(int x)
        {
            if (x == Count) return true;
            else return false;
        }
    }
}
