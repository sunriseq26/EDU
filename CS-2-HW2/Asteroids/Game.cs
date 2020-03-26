//Иван Кустарников

//Домашнее задание.
//2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
//3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
//4. Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
//5. * Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками(например, отрицательные размеры, слишком большая скорость или позиция).

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
                Image astr = Image.FromFile(@"Images\Asteroids\0" + rnd.Next(0, 4).ToString() + ".png");

                int e = rnd.Next(35, 60);

                objs[i] = new Asteroid(new Point(c, b), new Point(d, d), new Size(e, e), astr);
            }

            bullet = new Bullet(new Point(0, Game.Height / 2), new Point(d, d), new Size(35, 20), imgBullet);
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
