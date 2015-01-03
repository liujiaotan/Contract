using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Module
    {
        public Module()
        {
            this.Roles = new List<Role>();
        }

        public byte FunctionID { get; set; }
        public byte OperationID { get; set; }
        public virtual Function Function { get; set; }
        public virtual Operation Operation { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
