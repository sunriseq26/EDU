//Иван Кустарников

//Домашнее задание.
//1. Переопределить Update для класса Star, чтобы звезды двигались плавно из одной стороны экрана в другую. (слева на права или сверху вниз). При выходе за область экрана звезда должна появляться с другой стороны в произвольном месте.Используйте статическое поле Random внутри класса Game.
//2. Добавить класс Asteroids, который можно наследовать от класса BaseObject и которые тоже движутся как и звезды, но при исчезновении с экрана они меняли свою картинку.

// Для проверки собственного исключения нужно раскомментировать 72 строку и закомментировать 71 строку в классе Game.cs

using System.Drawing;

namespace SpaceWars.Objects
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

    /// <summary>
    /// Базовый класс объектов. Создает различные объекты и описывает их движение
    /// </summary>
    abstract class BaseObject : ICollision
    {
        protected Point pos;//Позиция
        protected Point dir;//Направление
        protected Size size;//Размер
        protected Image img;//Размер

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
        abstract public void SetImg(Image _img);

        abstract public int GetPosX();

        abstract public void SetPosY(int b);

        /// <summary>
        /// Метод, который рисует объекты
        /// </summary>
        abstract public void Draw();

        /// <summary>
        /// Метод, который описывает движение объекта
        /// </summary>
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

    /// <summary>
    /// Класс объектов типа Звезда. Создает звезды и описывает их движение
    /// </summary>
    class Star :BaseObject
    {
        ////// <summary>
        /// Конструктор. Создает объекты. 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        /// <param name="img"></param>
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

        /// <summary>
        /// Метод, который присваивает объекту картинку
        /// </summary>
        /// <param name="_img"></param>
        public override void SetImg(Image _img)
        {
            img = _img;
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Метод, который рисует объекты
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Метод, который описывает движение объекта
        /// </summary>
        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
            if (pos.X < -size.Width) pos.X = Game.Width;
        }

    }

    /// <summary>
    /// Класс объектов типа Астероид. Создает астероиды и описывает их движение
    /// </summary>
    class Asteroid :BaseObject
    {
        /// <summary>
        /// Конструктор. Создает объекты. 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        /// <param name="img"></param>
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

        /// <summary>
        /// Метод, который присваивает объекту картинку
        /// </summary>
        /// <param name="_img"></param>
        public override void SetImg(Image _img)
        {
            img = _img;
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Метод, который рисует объекты
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Метод, который описывает движение объекта
        /// </summary>
        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
            if (pos.X < -size.Width) pos.X = Game.Width;
        } 
    }

    /// <summary>
    /// Класс объектов типа Пуля. Создает пули и описывает их движение
    /// </summary>
    class Bullet : BaseObject
    {
        /// <summary>
        /// Конструктор. Создает объекты. 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        /// <param name="img"></param>
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

        /// <summary>
        /// Метод, который присваивает объекту картинку
        /// </summary>
        /// <param name="_img"></param>
        public override void SetImg(Image _img)
        {
            img = _img;
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Метод, который рисует объекты
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);

        }

        /// <summary>
        /// Метод, который описывает движение объекта
        /// </summary>
        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y;
            if (pos.X > Game.Width + size.Width) pos.X = -size.Width;
        }
    }

    /// <summary>
    /// Класс объектов типа Фон. Создает фон и описывает их движение
    /// </summary>
    class Background : BaseObject
    {
        /// <summary>
        /// Конструктор. Создает объекты. 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        /// <param name="img"></param>
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

        /// <summary>
        /// Метод, который присваивает объекту картинку
        /// </summary>
        /// <param name="_img"></param>
        public override void SetImg(Image _img)
        {
            img = _img;
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Метод, который рисует объекты
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width, size.Height);

        }

        /// <summary>
        /// Метод, который описывает движение объекта
        /// </summary>
        public override void Update()
        {
            pos.X = pos.X - dir.X;
            pos.Y = pos.Y;
        }
    }
}
