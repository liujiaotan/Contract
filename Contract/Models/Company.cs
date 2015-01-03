using System;
using System.Collections.Generic;

namespace Contract.Models
{
    public partial class Company
    {
        public Company()
        {
            this.Contacts = new List<Contact>();
            this.Tenancies = new List<Tenancy>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string JuridicalPerson { get; set; }
        public string Address { get; set; }
        public System.DateTime CreateDate { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Tenancy> Tenancies { get; set; }
    }
}
