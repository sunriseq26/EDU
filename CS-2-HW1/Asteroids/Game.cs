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
        static Image background = Image.FromFile("Images\\fon.jpg");
        static Image image = Image.FromFile("Images\\star.png");
        static Random rnd = new Random();
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

            for (int i = 0; i < objs.Length/2; i++)
            {
                int b = rnd.Next(0, Height);
                int c = rnd.Next(0, Width);
                int d = rnd.Next(30, 45);
                objs[i] = new Star(new Point(c, b), new Point(d, d), new Size(10, 10), image);
            }

            for (int i = 30; i < objs.Length; i++)
            {
                int b = rnd.Next(0, Height);
                int c = rnd.Next(0, Width);
                int d = rnd.Next(5, 10);
                Image astr = Image.FromFile(@"Images\Asteroids\0" + rnd.Next(0, 4).ToString() + ".png");
                objs[i] = new Asteroid(new Point(c, b), new Point(d, d), new Size(50, 50), astr);
            }
            
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
            
            buffer.Graphics.DrawImage(background, 0, 0);
            int count = 0;

            foreach (BaseObject obj in objs)
            {
                if (count >= 30 & obj.GetPosX() == -2)
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
            buffer.Render();
        }

        static public void Update()
        {

            int countUpd = 0;

            foreach (BaseObject obj in objs)
            {


                if (obj.GetPosX() == -2)
                {
                    int b = rnd.Next(0, Height);
                    obj.SetPosY(b);
                    countUpd++;
                }
                else
                {
                    obj.Update();
                    countUpd++;
                }


            }

        }

    }
}
