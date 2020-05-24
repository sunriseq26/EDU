//Иван Кустарников

//Домашнее задание.
//1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.
//2. * Заменить кружочки картинками, используя метод DrawImage.

using System;
using System.Drawing;

namespace MyGame.Objects
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

    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size, Image img) :
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
            pos.X = Game.Width;
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
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
            if (pos.X < -size.Width) pos.X = Game.Width;
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
            pos.X = Game.Width;
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
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
            if (pos.X < -size.Width) pos.X = Game.Width;
        }

    }

    class Background : BaseObject
    {
        public Background(Point pos, Point dir, Size size, Image img) :
            base(pos, dir, size, img)
        {
        }
        public override int GetPosX()
        {
            return pos.X;
        }

        public override void SetPosY(int b)
        {
            pos.Y = -40;
            pos.X = b;
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
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
        }
    }
}
