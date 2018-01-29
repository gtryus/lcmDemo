// Copyright (c) 2010-2018 SIL International
// License: MIT
using System;
using System.Windows.Forms;

namespace lcmDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProjectInfo());
        }
    }
}
