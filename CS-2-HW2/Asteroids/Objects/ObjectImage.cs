//Иван Кустарников

//Домашнее задание.
//1. Переопределить Update для класса Star, чтобы звезды двигались плавно из одной стороны экрана в другую. (слева на права или сверху вниз). При выходе за область экрана звезда должна появляться с другой стороны в произвольном месте.Используйте статическое поле Random внутри класса Game.
//2. Добавить класс Asteroids, который можно наследовать от класса BaseObject и которые тоже движутся как и звезды, но при исчезновении с экрана они меняли свою картинку.

// Для проверки собственного исключения нужно раскомментировать 72 строку и закомментировать 71 строку в классе Game.cs

using System.Drawing;
using System.Collections.Generic;

namespace SpaceWars.Objects
{
    /// <summary>
    /// Класс, который хранит картинки для объектов
    /// </summary>
    class ObjectImage
    {
        /// <summary>
        /// Список картинок для объектов
        /// </summary>
        static public List<Image> Inst { get; }

        /// <summary>
        /// Конструктор для создания списка картинок для объектов
        /// </summary>
        static ObjectImage()
        {
            Inst = new List<Image>();
            Inst.Add(Image.FromFile(@"Images\Asteroids\00.png"));
            Inst.Add(Image.FromFile(@"Images\Asteroids\01.png"));
            Inst.Add(Image.FromFile(@"Images\Asteroids\02.png"));
            Inst.Add(Image.FromFile(@"Images\Asteroids\03.png"));
        }
    }
}
