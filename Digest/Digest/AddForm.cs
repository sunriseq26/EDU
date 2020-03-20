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
    public partial class AddForm : Form
    {
        public Element Element { get; private set; } = new Element();
        Elements database = new Elements();
        public AddForm()
        {
            InitializeComponent();
            cbGenre.Items.AddRange(database.ListGenre);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Element.Author = tbAuthor.Text;
            Element.Notes = tbNotes.Text;
            Element.Title = tbTitle.Text;
            Element.Date = tpDate.Text;
            Element.Genre = cbGenre.Text;
            DialogResult = DialogResult.OK;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
