using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.UI.Events
{
    public class AfterDetailDeletedEvent:PubSubEvent<AfterDetailsDeletedEventArgs>
    {

    }
    public class AfterDetailsDeletedEventArgs
    {
        public int Id { get; set; }
        public string ViewModelName { get; set; }
    }
}
