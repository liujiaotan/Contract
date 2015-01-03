using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Function
    {
        public Function()
        {
            this.Modules = new List<Module>();
        }

        public byte ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Controller { get; set; }
        public bool IsRoot { get; set; }
        public bool IsTag { get; set; }
        public bool IsSystem { get; set; }
        public byte ParentID { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
