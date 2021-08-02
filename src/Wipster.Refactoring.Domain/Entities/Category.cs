using System.Collections.Generic;

namespace Wipster.Refactoring.Domain.Entities
{    //Anemic Entities. The domain behaviors have not been modelled here, thus the behaviors are mutable and unpredictable. 
    public class Category
    {
        public Category()
        {
            //?? Hash set
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; private set; }
    }
}
