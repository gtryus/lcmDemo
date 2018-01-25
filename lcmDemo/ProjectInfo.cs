// Copyright (c) 2010-2018 SIL International
// License: MIT
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SIL.LCModel;
using SIL.WritingSystems;

namespace lcmDemo
{
    public partial class ProjectInfo : Form
    {
        public string SelectedProject { get; set; }
        public LcmCache _cache;

        public ProjectInfo()
        {
            InitializeComponent();
        }

        private void ProjectInfo_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedProject))
            {
                var dlg = new ChooseProject();
                if (dlg.ShowDialog() == DialogResult.OK)
                    SelectedProject = dlg.SelectedProject;
                else
                    throw new InvalidOperationException();
            }
            SIL.LCModel.Core.Text.Icu.InitIcuDataDir();
            if (!Sldr.IsInitialized) Sldr.Initialize(true);
            var dirs = new MyDirs();
            var projectPath = Path.Combine(dirs.ProjectsDirectory, SelectedProject, SelectedProject + LcmFileHelper.ksFwDataXmlFileExtension);
            var ui = new SilentLcmUI(SynchronizeInvoke);
            var settings = new LcmSettings { DisableDataMigration = true, UpdateGlobalWSStore = false };
            //using (var progressDlg = new MyProgress())
            //{
            //    _cache = LcmCache.CreateCacheFromLocalProjectFile(projectPath, Thread.CurrentThread.CurrentUICulture.Name, ui, dirs, settings, progressDlg);
            //}
            using (var progressDlg = new MyProgress())
            {
                _cache = LcmCache.CreateCacheFromExistingData(new LocalProjectId(BackendProviderType.kSharedXML, projectPath), Thread.CurrentThread.CurrentUICulture.Name, ui, dirs, settings, progressDlg);
            }

        }

        public ISynchronizeInvoke SynchronizeInvoke
        {
            get
            {
                Form form = Form.ActiveForm;
                if (form != null)
                    return form;
                if (Application.OpenForms.Count > 0)
                    return Application.OpenForms[0];
                return null;
            }
        }

    }
}
