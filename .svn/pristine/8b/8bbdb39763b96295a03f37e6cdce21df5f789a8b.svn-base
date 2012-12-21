using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Net.Mail;

namespace ErrorLoggerService
{
    public partial class ErrorLoggerService : ServiceBase
    {
        private ErrorLoggerApp _app;

        public ErrorLoggerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_app == null)
                _app = new ErrorLoggerApp();
            _app.Start();
        }

        protected override void OnStop()
        {
            if (_app != null)
                _app.Stop();
        }
    }
}

