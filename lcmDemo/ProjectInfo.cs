// Copyright (c) 2010-2018 SIL International
// License: MIT
using System;
using System.ComponentModel;
using System.Linq;
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
                if (dlg.ShowDialog() != DialogResult.OK) throw new InvalidOperationException();
                SelectedProject = dlg.SelectedProject;
            }
            SIL.LCModel.Core.Text.Icu.InitIcuDataDir();
            if (!Sldr.IsInitialized) Sldr.Initialize(true);
            var dirs = new MyDirs();
            var projectFolder = Path.IsPathRooted(SelectedProject) ? Path.GetDirectoryName(Path.GetDirectoryName(SelectedProject)) : dirs.ProjectsDirectory;
            var name = Path.GetFileNameWithoutExtension(SelectedProject);
            var projectPath = Path.Combine(projectFolder, name, name + LcmFileHelper.ksFwDataXmlFileExtension);
            var ui = new SilentLcmUI(SynchronizeInvoke);
            var settings = new LcmSettings { DisableDataMigration = true, UpdateGlobalWSStore = false };
            using (var progressDlg = new MyProgress())
            {
                _cache = LcmCache.CreateCacheFromExistingData(new LocalProjectId(BackendProviderType.kSharedXML, projectPath), Thread.CurrentThread.CurrentUICulture.Name, ui, dirs, settings, progressDlg);
            }
            NameTb.Text = _cache.ProjectId.Name;
            PopulateWritingSystemsList();
            var svcloc = _cache.ServiceLocator;
            var entries = svcloc.GetInstance<ILexEntryRepository>().AllInstances()
                .Where(lx => lx.LexemeFormOA != null && lx.LexemeFormOA.Form.StringCount > 0)
                .ToList();
            EntryCountTb.Text = entries.Count.ToString();
        }

        private void PopulateWritingSystemsList()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Type");
            var col1 = listView1.Columns.Add("Name");
            col1.Width *= 3;
            var col2 = listView1.Columns.Add("Id");
            col2.Width *= 2;
            foreach (var ws in _cache.LangProject.VernacularWritingSystems)
            {
                listView1.Items.Add(new ListViewItem(new string[] { "Vernacular", ws.LanguageName, ws.Id }));
            }
            foreach (var ws in _cache.LangProject.AnalysisWritingSystems)
            {
                listView1.Items.Add(new ListViewItem(new string[] { "Analysis", ws.LanguageName, ws.Id }));
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
