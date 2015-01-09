using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class ServiceCenter
    {
        public ServiceCenter()
        {
            this.Rooms = new List<Room>();
            this.Employees = new List<Employee>();
            this.Tenancies = new List<Tenancy>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Tenancy> Tenancies { get; set; }
    }
}
