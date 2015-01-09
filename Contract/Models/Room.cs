using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Room
    {
        public Room()
        {
            this.Tenancies = new List<Tenancy>();
        }

        public int ID { get; set; }
        public int ServiceCenterID { get; set; }
        public int Category { get; set; }
        public int Type { get; set; }
        public byte State { get; set; }
        public byte Floor { get; set; }
        public string Number { get; set; }
        public decimal Space { get; set; }
        public string Description { get; set; }
        public System.DateTime CreateDate { get; set; }
        public virtual RoomCategory RoomCategory { get; set; }
        public virtual RoomState RoomState { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ICollection<Tenancy> Tenancies { get; set; }
    }
}
