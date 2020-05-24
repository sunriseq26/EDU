//Иван Кустарников

//Домашнее задание.
//1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.
//2. * Заменить кружочки картинками, используя метод DrawImage.

using System;
using System.Drawing;
using System.Windows.Forms;
using MyGame.Objects;

namespace MyGame
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
        static Random rnd = new Random();
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
            ScaleWidth = form.CurrentAutoScaleDimensions.Width;
            form.MaximumSize = new Size(Width, Height);
            form.MinimumSize= new Size(Width, Height);
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }

        static public void Load()
        {
            objs = new BaseObject[60];

            int a = rnd.Next(1, 600);
            int b = rnd.Next(0, Height);
            int c = rnd.Next(0, Width);
            int d = rnd.Next(5, 10);
            int e = rnd.Next(2, 7);

            for (int i = 0; i < objs.Length/2; i++)
            {
                b = rnd.Next(0, Height);
                c = rnd.Next(0, Width);
                d = rnd.Next(10, 25);
                e = rnd.Next(2, 7);
                objs[i] = new Star(new Point(c, b), new Point(d, d), new Size(e, e), image);
            }

            for (int i = 30; i < objs.Length; i++)
            {
                b = rnd.Next(0, Height - 80);
                c = rnd.Next(0, Width);
                d = rnd.Next(5, 10);
                Image astr = Image.FromFile(@"Images\Asteroids\0" + rnd.Next(0, 4).ToString() + ".png");
                objs[i] = new Asteroid(new Point(c, b), new Point(d, d), new Size(50, 50), astr);
            }

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
