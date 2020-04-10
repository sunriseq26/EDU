﻿//Иван Кустарников

//Домашнее задание.
//2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
//3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
//4. Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
//5. * Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками(например, отрицательные размеры, слишком большая скорость или позиция).
using System;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main()
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            Game.Load();
            form.Show();
            Game.Draw();
            Application.Run(form);

            
            //Math.Sqrt(4);
        }
    }
}