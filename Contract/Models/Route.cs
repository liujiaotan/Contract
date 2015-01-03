using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Route
    {
        public int ID { get; set; }
        public byte ProcessID { get; set; }
        public int ToTask { get; set; }
        public int FromTask { get; set; }
        public virtual Process Process { get; set; }
        public virtual Task Task { get; set; }
        public virtual Task Task1 { get; set; }
    }
}
