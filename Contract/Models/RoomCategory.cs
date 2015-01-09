using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class RoomCategory
    {
        public RoomCategory()
        {
            this.Rooms = new List<Room>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
