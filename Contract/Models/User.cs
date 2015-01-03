using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
