using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            this.Rooms = new List<Room>();
        }

        public byte ID { get; set; }
        public string Name { get; set; }
        public bool IsRentable { get; set; }
        public System.DateTime CreateDate { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
