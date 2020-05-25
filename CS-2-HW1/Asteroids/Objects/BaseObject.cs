//Иван Кустарников

//Домашнее задание.
//1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.
//2. * Заменить кружочки картинками, используя метод DrawImage.

using System;
using System.Drawing;

namespace MyGame.Objects
{
    /// <summary>
    /// Базовый класс объектов. Создает различные объекты и описывает их движение
    /// </summary>
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        protected Image img;

        /// <summary>
        /// Конструктор. Создает объекты. 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        /// <param name="img"></param>
        public BaseObject(Point pos, Point dir, Size size, Image img)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
            this.img = img;
        }

        /// <summary>
        /// Метод, который присваивает объекту картинку
        /// </summary>
        /// <param name="_img"></param>
        virtual public void SetImg(Image _img)
        {
            img = _img;
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        virtual public int GetPosX()
        {
            return pos.X;
        }

        virtual public void SetPosY(int b)
        {
            pos.Y = b;
            pos.X = Game.Width;
        }

        /// <summary>
        /// Метод, который рисует объекты
        /// </summary>
        virtual public void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Метод, который обновляет положение объекта
        /// </summary>
        virtual public void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
            if (pos.X < -size.Width) pos.X = Game.Width;
        }

    }

    /// <summary>
    /// Класс, который описывает объект типа - звезда
    /// </summary>
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size, Image img) :
            base(pos, dir, size, img)
        {
        }


        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }
    }

    /// <summary>
    /// Класс, который описывает объект типа - астероид
    /// </summary>
    class Asteroid : BaseObject
    {
        public Asteroid(Point pos, Point dir, Size size, Image img) :
            base(pos, dir, size, img)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }
    }

    /// <summary>
    /// Класс, который описывает объект типа - фон
    /// </summary>
    class Background : BaseObject
    {
        public Background(Point pos, Point dir, Size size, Image img) :
            base(pos, dir, size, img)
        {
        }

        public override void SetPosY(int b)
        {
            pos.Y = -40;
            pos.X = b;
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);

        }

        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
        }
    }
}
