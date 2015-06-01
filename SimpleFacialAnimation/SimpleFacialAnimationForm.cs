using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MaxCustomControls;

namespace SimpleFacialAnimation
{
    public partial class SimpleFacialAnimationForm : MaxForm
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
            var timeline = TimelineParser.Parse(xmlTextBox.Text);
            var u = 0;
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Simple Facial Animation File|*.sfa",
                Title = "Open  File"
            };
            dlg.ShowDialog();

            using (var reader = new StreamReader(dlg.OpenFile(), Encoding.UTF8))
            {
                xmlTextBox.Text = reader.ReadToEnd();                
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "Simple Facial Animation File|*.sfa",
                Title = "Save File"
            };
            dlg.ShowDialog();

            using (var writer = new StreamWriter(dlg.OpenFile(), Encoding.UTF8))
            {
                writer.WriteLine(xmlTextBox.Text);
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            TimelineUtils.PlayAnimation();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            TimelineUtils.ResetModel();
        }
    }
}
