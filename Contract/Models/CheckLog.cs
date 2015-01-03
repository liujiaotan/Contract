using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class CheckLog
    {
        public int ID { get; set; }
        public int TenancyID { get; set; }
        public int TaskID { get; set; }
        public int EmployeeID { get; set; }
    }
}
