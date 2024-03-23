using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace first_lab
{
    public partial class Form2 : Form
    {
        public string Destination { get; private set; }
        public DateTime Date { get; private set; }

        public Form2()
        {
            InitializeComponent();
            this.Text = "Filter by...";
            dateTimePickerFilterDate.Value = DateTime.Today;

        }
        private void buttonApplyFilter_Click_1(object sender, EventArgs e)
        {
            Destination = textBoxDestination.Text;
            Date = dateTimePickerFilterDate.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
