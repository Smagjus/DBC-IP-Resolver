﻿using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;


namespace IP_Resolver
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

            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool administrativeMode = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!administrativeMode)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.Verb = "runas";
                startInfo.FileName = Application.ExecutablePath;
                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                return;
            }
            Application.Run(new Form1());
        }
    }
}
