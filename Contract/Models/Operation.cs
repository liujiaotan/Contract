using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Operation
    {
        public Operation()
        {
            this.Modules = new List<Module>();
        }

        public byte ID { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
