//Кустарников Иван

// Программа собирает коллекцию фильмов, при желании можно отсортировать по жанрам

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
    public partial class MainForm : Form
    {
        Timer timer = new Timer();
        Elements database = new Elements();
        Elements filter = new Elements();
        public MainForm()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            tsStatusDate.Text = DateTime.Now.ToLongTimeString();
            timer.Start();
            database.Load("database.XML");
            cbFilter.Items.AddRange(database.ListGenre);
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            UpdateInfo();
            FilterInfo();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tsStatusDate.Text = DateTime.Now.ToLongTimeString();
        }

        private void UpdateInfo()
        {
            Element element = database.CurrentElement;
            if (element == null) return;
            tbTitle.Text = element.Title;
            tbAuthor.Text = element.Author;
            tbDate.Text = element.Date;
            tbGenre.Text = element.Genre;
            tbNotes.Text = element.Notes;
            tstbCurrentNumber.Text = database.CurrentNumber.ToString();
        }

        private void FilterInfo()
        {
            Element element = filter.ListCurrentElement;
            if (element == null) return;
            tbTitle.Text = element.Title;
            tbAuthor.Text = element.Author;
            tbDate.Text = element.Date;
            tbGenre.Text = element.Genre;
            tbNotes.Text = element.Notes;
            tstbCurrentNumberGenre.Text = filter.ListCurrentNumber.ToString();
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            database.Prev();
            UpdateInfo();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            database.Next();
            UpdateInfo();
        }

        private void tsbPrevGenre_Click(object sender, EventArgs e)
        {
            filter.Prev();
            FilterInfo();
        }

        private void tsbNextGenre_Click(object sender, EventArgs e)
        {
            filter.Next();
            FilterInfo();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            AddForm addElement = new AddForm();
            addElement.ShowDialog();
            if (addElement.DialogResult == DialogResult.OK)
            {
                database.Add(addElement.Element);
                miSave.PerformClick();
                UpdateInfo();
            }
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            database.Save("database.XML");

            //SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Filter = "XML файл|*.XML|Все файлы|*.*";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    database.Save(dialog.FileName);
            //}
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML файл|*.XML|Все файлы|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                database.Load(dialog.FileName);
                
                UpdateInfo();
            }
            
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            miSave.PerformClick();
            //database.Save("database.XML");
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = cbFilter.SelectedItem.ToString();
            //foreach (Element el in database.list)
            //{
            //    filter.Add(el);
            //}
            filter.Filter(selectedState, filter);
            FilterInfo();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
