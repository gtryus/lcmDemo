using System;
using System.ComponentModel;
using System.Windows.Forms;
using SIL.LCModel.Utils;

namespace lcmDemo
{
    public partial class MyProgress : Form, IThreadedProgress
    {
        private bool startCancel;
        private bool finishCancel;

        public MyProgress()
        {
            InitializeComponent();
        }

        public bool Canceled { get { return finishCancel; } }

        public bool IsCanceling { get { return startCancel && !finishCancel; } }

        public string Title { get { return base.Text;  } set { base.Text = value; } }
        public string Message { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public int Position { get { return progressBar1.Value; } set { progressBar1.Value = value; } }
        public int StepSize { get { return progressBar1.Step; } set { progressBar1.Step = value; } }
        public int Minimum { get { return progressBar1.Minimum;  } set { progressBar1.Minimum = value; } }
        public int Maximum { get { return progressBar1.Maximum; } set { progressBar1.Maximum = value; } }

        public ISynchronizeInvoke SynchronizeInvoke => throw new NotImplementedException();

        public bool IsIndeterminate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AllowCancel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event CancelEventHandler Canceling;

        public object RunTask(Func<IThreadedProgress, object[], object> backgroundTask, params object[] parameters)
        {
            return backgroundTask(this, parameters);
        }

        public object RunTask(bool fDisplayUi, Func<IThreadedProgress, object[], object> backgroundTask, params object[] parameters)
        {
            return backgroundTask(this, parameters);
        }

        public void Step(int amount)
        {
            progressBar1.Value += progressBar1.Step;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            startCancel = true;
            Canceling?.Invoke(this, (CancelEventArgs)e);
            finishCancel = true;
            DialogResult = DialogResult.Cancel;
        }
    }
}
