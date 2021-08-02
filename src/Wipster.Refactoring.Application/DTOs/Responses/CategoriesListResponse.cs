using System.Collections.Generic;

namespace Wipster.Refactoring.Application.Dtos
{
    public class CategoriesListResponse
    {
        // Why is the list another Response Type. I would remove the name response out of all the DTOs. 
        // 
        public IList<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();

        //Pointless property. This can be deduced. If at all necessary this should deduce the output as below
        public int Count => Categories.Count;
    }
}
