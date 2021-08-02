using System.Collections.Generic;

namespace Wipster.Refactoring.Application.Dtos
{
    public class ProductsListResponse
    {
        public IList<ProductResponse> Products { get; set; } = new List<ProductResponse>();

        //?? this logic belongs in the domain model and should be a behavior specific to the model existence condition 
        public bool CreateEnabled { get; set; }
    }
}
