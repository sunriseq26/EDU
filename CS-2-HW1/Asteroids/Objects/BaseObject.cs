//Иван Кустарников

//Домашнее задание.
//1. Переопределить Update для класса Star, чтобы звезды двигались плавно из одной стороны экрана в другую. (слева на права или сверху вниз). При выходе за область экрана звезда должна появляться с другой стороны в произвольном месте.Используйте статическое поле Random внутри класса Game.
//2. Добавить класс Asteroids, который можно наследовать от класса BaseObject и которые тоже движутся как и звезды, но при исчезновении с экрана они меняли свою картинку.

using System;
using System.Drawing;

namespace Asteroids.Objects
{
    class BaseObject
    {
        protected Point pos;//Позиция
        protected Point dir;//Направление
        protected Size size;//Размер
        protected Image img;//Размер


        public BaseObject(Point pos, Point dir, Size size, Image img)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
            this.img = img;
        }

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
            pos.X = 0;
        }

        virtual public void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }

        virtual public void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) pos.X = -2;
        }

    }

    class Star:BaseObject
    {
        public Star(Point pos, Point dir, Size size, Image img) :
            base(pos,dir,size,img)
        {
        }
        public override int GetPosX()
        {
            return pos.X;
        }

        public override void SetPosY(int b)
        {
            pos.Y = b;
            pos.X = 0;
        }

        public override void SetImg(Image _img)
        {
            img = _img;
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) pos.X = -2;
        }

    }

    class Asteroid : BaseObject
    {
        public Asteroid(Point pos, Point dir, Size size, Image img) :
            base(pos, dir, size, img)
        {

        }

        public override int GetPosX()
        {
            return pos.X;
        }

        public override void SetPosY(int b)
        {
            pos.Y = b;
            pos.X = 0;
        }

        public override void SetImg(Image _img)
        {
            img = _img;
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y;
            if (pos.X > Game.Width) pos.X = -2;
        }

    }
}
