// Copyright (c) 2010-2018 SIL International
// License: MIT
using System;
using System.IO;
using System.Windows.Forms;

namespace lcmDemo
{
    public partial class ChooseProject : Form
    {
        public string SelectedProject { get; private set; }

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
            Ok.Enabled = false;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= listBox1.Items.Count) return;
            SelectedProject = (string)listBox1.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

		private void AnotherLocationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = @"Data (*.fwdata)|*.fwdata|Backup (*.fwbackup)|*.fwbackup|All FieldWorks Data|*.fwdata;*.fwbackup";
			dlg.FilterIndex = 1;
			dlg.CheckFileExists = true;
            dlg.InitialDirectory = @"C:\ProgramData\SIL\FieldWorks\Projects";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (dlg.FileName.EndsWith(".fwbackup")) throw new NotImplementedException("Backup restore");
				SelectedProject = dlg.FileName;
				DialogResult = DialogResult.OK;
				Close();
			}
		}

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ok.Enabled = (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < listBox1.Items.Count);
        }
    }
}
