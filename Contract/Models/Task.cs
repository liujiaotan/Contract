using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Task
    {
        public Task()
        {
            this.Routes = new List<Route>();
            this.Routes1 = new List<Route>();
        }

        public int ID { get; set; }
        public byte ProcessID { get; set; }
        public string Name { get; set; }
        public string NoteType { get; set; }
        public string ProcessLogic { get; set; }
        public int AssignedRole { get; set; }
        public int DueDate { get; set; }
        public virtual Role Role { get; set; }
        public virtual Process Process { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
        public virtual ICollection<Route> Routes1 { get; set; }
    }
}
