using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Tenancy
    {
        public Tenancy()
        {
            this.Rooms = new List<Room>();
        }

        public int ID { get; set; }
        public int ServiceCenterID { get; set; }
        public byte ProcessID { get; set; }
        public int CompanyID { get; set; }
        public string Number { get; set; }
        public decimal UnitCost { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal HeatingFee { get; set; }
        public decimal ElectricityRate { get; set; }
        public int LeaseTerm { get; set; }
        public Nullable<System.DateTime> EffectDate { get; set; }
        public virtual Company Company { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual Process Process { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
