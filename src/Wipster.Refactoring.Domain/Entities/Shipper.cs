using System.Collections.Generic;

namespace Wipster.Refactoring.Domain.Entities
{
    public class Shipper
    {
        public Shipper()
        {
            //Hashset? 
            Orders = new HashSet<Order>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        // Rather Use Ilist
        public ICollection<Order> Orders { get; private set; }
    }
}
