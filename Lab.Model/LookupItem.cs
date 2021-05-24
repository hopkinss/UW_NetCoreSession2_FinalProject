using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Model
{
    public class LookupItem 
    {
        public int Id { get; set; }
        public string Display { get; set; }
    }
    public class NullLookupItem:LookupItem
    {
        public new int? Id { get { return null; } }
    }
}
