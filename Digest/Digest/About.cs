using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digest
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            string s = ("Программа собирает коллекцию фильмов, при желании можно отсортировать по жанрам");
            tbAbout.Text = s;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
