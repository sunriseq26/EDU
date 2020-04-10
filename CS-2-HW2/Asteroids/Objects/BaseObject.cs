//Иван Кустарников

//Домашнее задание.
//2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
//3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
//4. Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
//5. * Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками(например, отрицательные размеры, слишком большая скорость или позиция).

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

        //public void ChangeImg(Image _img1, Image _img2)
        //{
        //    if (img == _img1)
        //    {
        //        img = _img2;
        //        Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        //    }
        //    if (img == _img2)
        //    {
        //        img = _img1;
        //        Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        //    }
        //}

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);

        }

        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
            //if (pos.X == - size.Width) pos.X = size.Width;
        }
    }
}
