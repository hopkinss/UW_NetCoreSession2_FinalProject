using Autofac;
using Lab.Data;
using Lab.UI.Data;
using Lab.UI.Data.Lookups;
using Lab.UI.Data.Repository;
using Lab.UI.Utility;
using Lab.UI.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<LabDbContext>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<LabTestViewModel>().As<ILabTestViewModel>();
            builder.RegisterType<LabTestDetailViewModel>().As<ILabTestDetailViewModel>();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<LabTestRepository>().As<ILabTestRepository>();
            builder.RegisterType<MessageService>().As<IMessageService>();
 

            return builder.Build();
            
        }
    }
}
