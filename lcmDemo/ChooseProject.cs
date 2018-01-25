using System;
using System.IO;
using System.Windows.Forms;

namespace lcmDemo
{
    public partial class ChooseProject : Form
    {
        public string SelectedProject { get; set; }

        public ChooseProject()
        {
            InitializeComponent();
        }

        private void ChooseProject_Load(object sender, EventArgs e)
        {
            foreach (var project in Directory.GetDirectories(new MyDirs().ProjectsDirectory))
            {
                if (Directory.GetFiles(project, "*.fwdata").Length > 0)
                {
                    listBox1.Items.Add(Path.GetFileName(project));
                }
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            SelectedProject = (string)listBox1.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
