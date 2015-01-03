using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Process
    {
        public Process()
        {
            this.Tenancies = new List<Tenancy>();
            this.Routes = new List<Route>();
            this.Tasks = new List<Task>();
        }

        public byte ID { get; set; }
        public string Name { get; set; }
        public byte DueDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Tenancy> Tenancies { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
