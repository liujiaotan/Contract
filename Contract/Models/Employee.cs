using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Employee
    {
        public Employee()
        {
            this.TenancyCheckLogs = new List<TenancyCheckLog>();
            this.Roles = new List<Role>();
        }

        public int ID { get; set; }
        public int ServiceCenterID { get; set; }
        public string RealName { get; set; }
        public bool Sex { get; set; }
        public string Mobile { get; set; }
        public string QQ { get; set; }
        public string E_Mail { get; set; }
        public bool IsFreezed { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ICollection<TenancyCheckLog> TenancyCheckLogs { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
