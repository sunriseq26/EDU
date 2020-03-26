//Иван Кустарников

//Домашнее задание.
//1. Переопределить Update для класса Star, чтобы звезды двигались плавно из одной стороны экрана в другую. (слева на права или сверху вниз). При выходе за область экрана звезда должна появляться с другой стороны в произвольном месте.Используйте статическое поле Random внутри класса Game.
//2. Добавить класс Asteroids, который можно наследовать от класса BaseObject и которые тоже движутся как и звезды, но при исчезновении с экрана они меняли свою картинку.

using System;
using System.Drawing;
using System.Windows.Forms;
using Asteroids.Objects;

namespace Asteroids
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
                d = rnd.Next(10, 45); //для проверки работы исключения закомментировать
                //d = 2; //для проверки работы исключения раскомментировать
                if (d < 5)
                    throw new Exception("Значение для параметра d - направление должно быть больше 5");

                objs[i] = new Star(new Point(c, b), new Point(d, d), new Size(10, 10), image);
            }

            for (int i = 30; i < objs.Length; i++)
            {
                b = rnd.Next(0, Height);
                c = rnd.Next(0, Width);

                //Cобственное исключение GameObjectException
                d = rnd.Next(5, 10);//для проверки работы исключения закомментировать
                //d = 2; //для проверки работы исключения раскомментировать
                if (d < 5)
                    throw new Exception("Значение для параметра d - направление должно быть больше 5");
                Image astr = Image.FromFile(@"Images\Asteroids\0" + rnd.Next(0, 4).ToString() + ".png");

                objs[i] = new Asteroid(new Point(c, b), new Point(d, d), new Size(50, 50), astr);
            }

            bullet = new Bullet(new Point(0, Game.Height / 2), new Point(d, d), new Size(50, 30), imgBullet);
            objBackground1 = new Background(new Point(0, -40), new Point(3, d), new Size(imgWidth, imgHeight), background1);
            objBackground2 = new Background(new Point(imgWidth, -40), new Point(3, d), new Size(imgWidth, imgHeight), background2);

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        static public void Draw()
        {

            objBackground1.Draw();
            objBackground2.Draw();
            //buffer.Graphics.DrawImage(background, 0, -40);
            int count = 0;

            foreach (BaseObject obj in objs)
            {
                if (count >= 30 & obj.GetPosX() == Game.Width)
                {
                    Image astr = Image.FromFile(@"Images\Asteroids\0" + rnd.Next(0, 4).ToString() + ".png");
                    obj.SetImg(astr);
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
                    int b = rnd.Next(0, Height);
                    obj.SetPosY(b);
                    countUpd++;
                }
                else
                {
                    obj.Update();
                    if (countUpd >= 30 && obj.Collision(bullet))
                    {
                        //Console.WriteLine("Clash!");
                        int b = rnd.Next(40, Height-40);
                        obj.SetPosY(b);
                        bullet.SetPosY(b);
                        System.Media.SystemSounds.Hand.Play();
                    }
                    countUpd++;
                }
                

            }
            
            if (bullet.GetPosX() < 0)
            {
                int b = rnd.Next(0, Height);
                bullet.SetPosY(b);
            }
            else
            {
                bullet.Update();
            }

            
        }

    }
}
