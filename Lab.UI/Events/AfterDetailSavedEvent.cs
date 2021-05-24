using Lab.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.UI.Events
{
    public class AfterDetailSavedEvent: PubSubEvent<AfterDetailSavedEventArgs>
    {
    }

    public class AfterDetailSavedEventArgs
    {
        public int Id { get; set; }
        public string Display { get; set; }
        public string ViewModelName { get; set; }
    }
}
