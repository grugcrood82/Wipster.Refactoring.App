using System.Collections.Generic;
using System.Threading.Tasks;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Application.Dtos;

namespace Wipster.Refactoring.Application
{
    //Note CRUD service?? Seems like a pointless abstraction. Services must embody strict behavior orchestration
    //if this is absolutely necessary, this can be a generic class defining this behavior shared by other objects
    public interface ICategoriesService
    {
        Task<CategoriesListResponse> GetAll();
        Task<CategoryResponse> Get(int categoryId);
        Task<CategoryResponse> Create(CategoryRequest request);
        Task<CategoryResponse> Update(int categoryId, CategoryRequest request);
        Task<int> Delete(int categoryId);
    }
}