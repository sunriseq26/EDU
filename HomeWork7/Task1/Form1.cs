//Кустарников Иван

//а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
//б) Добавить меню и команду «Играть». При нажатии появляется сообщение, 
//какое число должен получить игрок.Игрок должен постараться получить это число за минимальное количество ходов.
//в) * Добавить кнопку «Отменить», которая отменяет последние ходы.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMI_Stavropol
{
    public partial class Form1 : Form
    {
        Udvoitel udvoitel;
        private List<string> listOperation = new List<string>(30);
        int x = 0;
        int y = 0;

        public Form1()
        {
            InitializeComponent();
            btnPlus.Enabled = false;
            btnMulti.Enabled = false;
            btnBack.Enabled = false;
            btnReset.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            udvoitel = new Udvoitel(new Random().Next(20, 101));
            MessageBox.Show("Наберите число: " + udvoitel.Target.ToString());
            ShowInfo();
            btnPlus.Enabled = true;
            btnMulti.Enabled = true;
            btnBack.Enabled = true;
            btnReset.Enabled = true;

            int Target = udvoitel.Target;

            int counter = 0;
            do
            {
                int i = Target;
                i = i % 2;

                if (i == 1)
                {
                    Target--;
                    counter++;
                }
                else
                {
                    Target /= 2;
                    counter++;
                }
            }
            while (Target > 1);
            x = counter;
            lblMaxCount.Text = Convert.ToString(x);
        }

        private void ShowInfo()
        {
            lblCount.Text = udvoitel.Count.ToString();
            lblCurrent.Text = udvoitel.Current.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            listOperation.Add("Plus");
            udvoitel.Plus();
            ShowInfo();
            if (udvoitel.Check() == GameState.Win && udvoitel.CountTry(x) == true)
                MessageBox.Show("Вы прирожденный математик! :) \n\nВы справились за " + udvoitel.Count.ToString() + " шагов", "Победа!");
            if (udvoitel.Check() == GameState.Win && udvoitel.CountTry(x) == false)
                MessageBox.Show("Неплохо, но необходимо потренироваться... :) \n\nВы справились за " + udvoitel.Count.ToString() + " шагов", "Победа!");
            if (udvoitel.Check() == GameState.More)
                MessageBox.Show("Перебор... :(", "Проигрыш!");
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            listOperation.Add("Multi");
            udvoitel.Multi();
            ShowInfo();
            udvoitel.Check();
            if (udvoitel.Check() == GameState.Win && udvoitel.CountTry(x) == true)
                MessageBox.Show("Вы прирожденный математик! :) \n\nВы справились за " + udvoitel.Count.ToString() + " шагов", "Победа!");
            if (udvoitel.Check() == GameState.Win && udvoitel.CountTry(x) == false)
                MessageBox.Show("Неплохо, но необходимо потренироваться... :) \n\nВы справились за " + udvoitel.Count.ToString() + " шагов", "Победа!");
            if (udvoitel.Check() == GameState.More)
                MessageBox.Show("Перебор... :(", "Проигрыш!");

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            udvoitel.Reset();
            ShowInfo();            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (listOperation.Count != 0)
            {
                if (listOperation[listOperation.Count - 1] == "Plus")
                    udvoitel.Back("Minus");
                if (listOperation[listOperation.Count - 1] == "Multi")
                        udvoitel.Back("Delete");
                listOperation.RemoveAt(listOperation.Count - 1);
                ShowInfo();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
