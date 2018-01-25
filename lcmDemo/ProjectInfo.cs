using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SIL.LCModel;
using System.Threading;
using SIL.WritingSystems;

namespace lcmDemo
{
    public partial class ProjectInfo : Form
    {
        public string SelectedProject { get; set; }

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
            if (!Sldr.IsInitialized) Sldr.Initialize(true);
            var projectId = new MyProjectIdentifier(BackendProviderType.kSharedXML, SelectedProject);
            var dirs = new MyDirs();
            var ui = new SilentLcmUI(SynchronizeInvoke);
            var settings = new LcmSettings();
            var progress = new MyProgress();
            //var cache = LcmCache.CreateCacheFromExistingData(projectId, "en", ui, dirs, settings, progress);
            var projectPath = Path.Combine(dirs.ProjectsDirectory, SelectedProject, SelectedProject + ".fwdata");
            var cache = LcmCache.CreateCacheFromLocalProjectFile(projectPath, "en", ui, dirs, settings, progress);

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
