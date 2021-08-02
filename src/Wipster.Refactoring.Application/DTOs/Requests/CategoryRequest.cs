using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wipster.Refactoring.Application.Dtos
{
    public class CategoryRequest
    {
        // Removed all not accessed properties
        // DTOs belong in the API and not here. 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
