using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class TenancyCheckLog
    {
        public int ID { get; set; }
        public int TenancyID { get; set; }
        public int EmployeeID { get; set; }
        public int TaskID { get; set; }
        public string Action { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public virtual Tenancy Tenancy { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
