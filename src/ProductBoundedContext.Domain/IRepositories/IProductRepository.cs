using ProductBoundedContext.Domain.EntityDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductBoundedContext.Domain.IRepositories
{
    public interface IProductRepository
    {
        Task<ProductEntityDomain> CreateProductAsync(ProductEntityDomain product);

        Task<bool> UpdateProductAsync(ProductEntityDomain product);

        Task<bool> RemoveProductAsync(string id);

        Task<List<ProductEntityDomain>> GetAllProductAsync();

        Task<ProductEntityDomain> GetProductAsync(string id);
    }
}