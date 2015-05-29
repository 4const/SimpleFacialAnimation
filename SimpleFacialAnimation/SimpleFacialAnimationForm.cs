using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFacialAnimation
{
    public partial class SimpleFacialAnimationForm : MaxCustomControls.MaxForm
    {
        public SimpleFacialAnimationForm()
        {
            InitializeComponent();
        }

        private void SimpleFacialAnimationForm_Load(object sender, EventArgs e)
        {

        }

        private void compileBtn_Click(object sender, EventArgs e)
        {

        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Simple Facial Animation File|*.sfa";
            dlg.Title = "Open  File";
            dlg.ShowDialog();

            using (var reader = new System.IO.StreamReader(dlg.OpenFile(), System.Text.Encoding.UTF8))
            {
                xmlTextBox.Text = reader.ReadToEnd();                
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Simple Facial Animation File|*.sfa";
            dlg.Title = "Save File";
            dlg.ShowDialog();

            using (var writer = new System.IO.StreamWriter(dlg.OpenFile(), System.Text.Encoding.UTF8))
            {
                writer.WriteLine(xmlTextBox.Text);
            }
        }
    }
}
