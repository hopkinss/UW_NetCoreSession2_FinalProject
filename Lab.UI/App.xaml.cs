using Autofac;
using Lab.UI.Startup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Lab.UI
{
    public partial class App : Application
    {
        public App()
        {
           this.InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var startup = new Bootstrapper();
            var dic = startup.Bootstrap();
            var mainwindow = dic.Resolve<MainWindow>();
            mainwindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {            
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }
    }
}
