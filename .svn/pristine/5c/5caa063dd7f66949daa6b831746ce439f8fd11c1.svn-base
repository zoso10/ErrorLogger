using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using System.IO;


namespace ErrorLoggerService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }


        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            // Start the service when the user installs it
            try
            {
                if(!Directory.Exists("C:\\ErrorLogger"))
                    Directory.CreateDirectory("C:\\ErrorLogger");
                ServiceController controller = new ServiceController("ErrorLoggerService");
                controller.Start();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Service not started.  You must manually start it.");
            }

        }
    }
}
