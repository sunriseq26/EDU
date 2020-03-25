//Иван Кустарников

//Домашнее задание.
//1. Переопределить Update для класса Star, чтобы звезды двигались плавно из одной стороны экрана в другую. (слева на права или сверху вниз). При выходе за область экрана звезда должна появляться с другой стороны в произвольном месте.Используйте статическое поле Random внутри класса Game.
//2. Добавить класс Asteroids, который можно наследовать от класса BaseObject и которые тоже движутся как и звезды, но при исчезновении с экрана они меняли свою картинку.

using System;
using System.Drawing;

namespace Asteroids.Objects
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
    abstract class BaseObject : ICollision
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

        abstract public void SetImg(Image _img);

        abstract public int GetPosX();

        abstract public void SetPosY(int b);

        abstract public void Draw();

        abstract public void Update();
        
        public bool Collision(ICollision obj)
        {
            return this.Rect.IntersectsWith(obj.Rect);
        }

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(pos, size);
            }
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

    class Asteroid:BaseObject
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
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size, Image img) :
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
            if (pos.X > Game.Width + size.Width) pos.X = -size.Width;
        }
    }
}
