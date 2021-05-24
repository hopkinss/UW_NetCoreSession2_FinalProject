using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.UI.Events
{
    public class OpenDetailViewEvent : PubSubEvent<OpenDetailViewEventArgs> { }
    public class OpenDetailViewEventArgs
    {
        public int? Id { get; set; }
        public string ViewModelName { get; set; }
    }
}
