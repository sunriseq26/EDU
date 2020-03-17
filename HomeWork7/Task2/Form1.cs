//Кустарников Иван

//Используя Windows Forms, разработать игру «Угадай число». 
//Компьютер загадывает число от 1 до 100, а человек пытается 
//его угадать за минимальное число попыток.Для ввода данных 
//от человека используется элемент TextBox.

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
        private Random rand = new Random();
        private int num;
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
            lblHelp.Text = "";
        }

        private void btnPlayRestart_Click(object sender, EventArgs e)
        {
            if (btnPlayRestart.Text == "Играть")
            {
                num = rand.Next(0, 101);
                btnPlayRestart.Text = "Заново";
                lblCount.Enabled = true;
                txtBoxEnter.Enabled = true;
                lblHelp.Text = "";
            }
            else
            {
                num = rand.Next(0, 101);
                count = 0;
                lblCount.Text = "Количество попыток: 0";
                txtBoxEnter.Text = "";
                btnTry.Enabled = false;
                lblHelp.Text = "";
            }
        }
        private void txtBoxEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (!Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            else
            {
                btnTry.Enabled = true;
            }
        }
        private void btnTry_Click(object sender, EventArgs e)
        {
            btnTry.Enabled = false; 
            int enterNum = Convert.ToInt32(txtBoxEnter.Text);
            if (enterNum > 100)
            {
                MessageBox.Show("Введенное значение больше допустимого. Введите другое",
                    "Угадай число");
                txtBoxEnter.Text = "";
            }
            else
            {
                lblCount.Text = "Количество попыток: " + (++count).ToString();
                if (enterNum > num) 
                    lblHelp.Text = "Ваше число больше"; 
                else if (enterNum < num) 
                    lblHelp.Text = "Ваше число меньше"; 
                else 
                {
                    MessageBox.Show("          Поздравляем!   \n" +
                                                 "Вы справились за " + count.ToString() + " попыток"
                                                 , "Угадай число");
                    txtBoxEnter.Text = ""; 
                    lblHelp.Text = "";
                    count = 0; 
                    lblCount.Text = "Количество попыток: 0"; 
                    lblCount.Enabled = false; 
                    txtBoxEnter.Enabled = false; 
                    btnPlayRestart.Text = "Играть"; 

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
