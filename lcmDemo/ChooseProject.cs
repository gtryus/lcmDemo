// Copyright (c) 2010-2018 SIL International
// License: MIT
using SIL.Tool;
using System;
using System.IO;
using System.Windows.Forms;

namespace lcmDemo
{
    public partial class ChooseProject : Form
    {
        public string SelectedProject { get; set; }
        public string ProjectFolder { get; private set; }

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
            ProjectFolder = new MyDirs().ProjectsDirectory;
            DialogResult = DialogResult.OK;
            Close();
        }

		private void AnotherLocationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = @"Data (*.fwdata)|*.fwdata|Backup (*.fwbackup)|*.fwbackup|All FieldWorks Data|*.fwdata;*.fwbackup";
			dlg.FilterIndex = 2;
			dlg.CheckFileExists = true;
			dlg.InitialDirectory = new MyDirs().BackupDirectory;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (dlg.FileName.EndsWith(".fwbackup")) throw new NotImplementedException("Backup restore");
				SelectedProject = Path.GetFileNameWithoutExtension(dlg.FileName);
				ProjectFolder = Path.GetDirectoryName(Path.GetDirectoryName(dlg.FileName));
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
