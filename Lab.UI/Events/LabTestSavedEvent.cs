using Lab.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.UI.Events
{
    public class LabTestSavedEvent: PubSubEvent<AfterLabTestSavedEventArgs>
    {
    }

    public class AfterLabTestSavedEventArgs
    {
        public int Id { get; set; }
        public string Display { get; set; }
    }
}
