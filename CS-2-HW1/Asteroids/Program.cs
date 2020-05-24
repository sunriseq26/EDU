//Иван Кустарников

//Домашнее задание.
//1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.
//2. * Заменить кружочки картинками, используя метод DrawImage.

using System;
using System.Windows.Forms;

namespace MyGame
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

        }
    }
}