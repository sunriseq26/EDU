//Иван Кустарников

//Домашнее задание.
//1. Переопределить Update для класса Star, чтобы звезды двигались плавно из одной стороны экрана в другую. (слева на права или сверху вниз). При выходе за область экрана звезда должна появляться с другой стороны в произвольном месте.Используйте статическое поле Random внутри класса Game.
//2. Добавить класс Asteroids, который можно наследовать от класса BaseObject и которые тоже движутся как и звезды, но при исчезновении с экрана они меняли свою картинку.

// Для проверки собственного исключения нужно раскомментировать 72 строку и закомментировать 71 строку в классе Game.cs

using System;
using System.Drawing;
using System.Windows.Forms;
using SpaceWars.Objects;

namespace SpaceWars
{
    static class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static public int Width { get; set; }
        static public int Height { get; set; }
        static public float ScaleWidth { get; set; }
        static public BaseObject[] objs;
        static Image background1 = Image.FromFile("Images\\fon1.jpg");
        static Image background2 = Image.FromFile("Images\\fon2.jpg");
        static Image image = Image.FromFile("Images\\star.png");
        static Image imgBullet = Image.FromFile("Images\\Gun\\01.png");
        static Random rnd = new Random();
        static Bullet bullet;
        static Background objBackground1;
        static Background objBackground2;
        static int imgWidth = Convert.ToInt32(background1.Size.Width.ToString());
        static int imgHeight = Convert.ToInt32(background1.Size.Height.ToString());

        static Game()
        {

        }

        /// <summary>
        /// Метод класса Game, который инициализирует размеры окна
        /// </summary>
        /// <param name="form"></param>
        static public void Init(Form form)
        {           
            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics(); 
            
            Width = form.Width;
            Height = form.Height;
            if (Width > 1000 || Height > 1000) 
                throw new ArgumentOutOfRangeException("Размеры ширины и высоты не могут иметь значение больше 1000");
            ScaleWidth = form.CurrentAutoScaleDimensions.Width;
            form.MaximumSize = new Size(Width, Height);
            form.MinimumSize= new Size(Width, Height);
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }

        /// <summary>
        /// Метод класса Game, который создает и загружает объекты
        /// </summary>
        static public void Load()
        {
            objs = new BaseObject[60];
            //Random rnd = new Random();
            int a = rnd.Next(1, 600);
            int b = rnd.Next(0, Height);
            int c = rnd.Next(0, Width);
            int d = rnd.Next(5, 10);

            for (int i = 0; i < objs.Length/2; i++)
            {
                b = rnd.Next(0, Height);
                c = rnd.Next(0, Width);

                //Cобственное исключение GameObjectException
                d = rnd.Next(10, 25); //для проверки работы исключения закомментировать
                //d = 2; //для проверки работы исключения раскомментировать

                int e = rnd.Next(2, 7);

                if (d < 5)
                    throw new Exception("Значение для параметра d - направление должно быть больше 5");

                objs[i] = new Star(new Point(c, b), new Point(d, d), new Size(e, e), image);
            }

            for (int i = 30; i < objs.Length; i++)
            {
                b = rnd.Next(0, (Height - 80));
                c = rnd.Next(0, Width);

                //Cобственное исключение GameObjectException
                d = rnd.Next(5, 10);//для проверки работы исключения закомментировать
                //d = 2; //для проверки работы исключения раскомментировать
                if (d < 5)
                    throw new Exception("Значение для параметра d - направление должно быть больше 5");

                int e = rnd.Next(35, 60);
                int f = rnd.Next(0, 3);

                objs[i] = new Asteroid(new Point(c, b), new Point(d, d), new Size(e, e), ObjectImage.Inst[f]);
            }

            bullet = new Bullet(new Point(0, Game.Height / 2), new Point(d, d), new Size(35, 20), imgBullet);
            objBackground1 = new Background(new Point(0, -40), new Point(3, d), new Size(imgWidth, imgHeight), background1);
            objBackground2 = new Background(new Point(imgWidth, -40), new Point(3, d), new Size(imgWidth, imgHeight), background2);

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        /// <summary>
        /// Метод класса Game, который заставляет двигать объекты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }


        /// <summary>
        ///  Метод класса Game, который присваивает форму и картники объектам
        /// </summary>
        static public void Draw()
        {

            objBackground1.Draw();
            objBackground2.Draw();
            int count = 0;

            foreach (BaseObject obj in objs)
            {
                if (count >= 30 & obj.GetPosX() == Game.Width)
                {
                    int f = rnd.Next(0, 3);
                    obj.SetImg(ObjectImage.Inst[f]);
                    count++;
                }
                else 
                {
                    obj.Draw();
                    count++;
                }  
            }
            bullet.Draw();
            buffer.Render();
        }


        /// <summary>
        /// Метод класса Game, который обновляет положение объектов и описывает их поведение
        /// </summary>
        static public void Update()
        {
            if (objBackground1.GetPosX() < -imgWidth)
            {
                int b = imgWidth;
                objBackground1.SetPosY(b);
            }
            if (objBackground2.GetPosX() < -imgWidth)
            {
                int b = imgWidth;
                objBackground2.SetPosY(b);
            }
            else
            {
                objBackground1.Update();
                objBackground2.Update();
            }

            int countUpd = 0;

            foreach (BaseObject obj in objs)
            {


                if (obj.GetPosX() > Width)
                {
                    int b = rnd.Next(0, (Height - 80));
                    obj.SetPosY(b);
                    countUpd++;
                }
                else
                {
                    obj.Update();
                    if (countUpd >= 30 && obj.Collision(bullet))
                    {
                        //Console.WriteLine("Clash!");
                        int b = rnd.Next(0, (Height - 80));
                        obj.SetPosY(b);
                        bullet.SetPosY(b);
                        System.Media.SystemSounds.Hand.Play();
                    }
                    countUpd++;
                }
                

            }
            
            if (bullet.GetPosX() < 0)
            {
                int b = rnd.Next(0, (Height - 80));
                bullet.SetPosY(b);
            }
            else
            {
                bullet.Update();
            }

            
        }

    }
}
