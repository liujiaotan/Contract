using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Tasks = new List<Task>();
            this.Modules = new List<Module>();
            this.Employees = new List<Employee>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
