﻿//Иван Кустарников

//Домашнее задание.
//1. Переопределить Update для класса Star, чтобы звезды двигались плавно из одной стороны экрана в другую. (слева на права или сверху вниз). При выходе за область экрана звезда должна появляться с другой стороны в произвольном месте.Используйте статическое поле Random внутри класса Game.
//2. Добавить класс Asteroids, который можно наследовать от класса BaseObject и которые тоже движутся как и звезды, но при исчезновении с экрана они меняли свою картинку.

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