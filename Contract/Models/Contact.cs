using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Contact
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string RealName { get; set; }
        public bool Sex { get; set; }
        public string Line { get; set; }
        public string Mobile { get; set; }
        public string Position { get; set; }
        public string QQ { get; set; }
        public string E_Mail { get; set; }
        public string MSN { get; set; }
        public System.DateTime CreateDate { get; set; }
        public virtual Company Company { get; set; }
    }
}
