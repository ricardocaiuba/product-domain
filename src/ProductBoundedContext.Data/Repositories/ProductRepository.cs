using System.Collections.Generic;
using System.Threading.Tasks;
using ProductBoundedContext.Data.Context;
using ProductBoundedContext.Domain.EntityDomain;
using ProductBoundedContext.Domain.IRepositories;
using Dapper;
using Dapper.Contrib.Extensions;
using ProductBoundedContext.Data.EntityData;
using System.Linq;

namespace ProductBoundedContext.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductSqlDataContext _ProductDataContext;

        public ProductRepository(ProductSqlDataContext productSqlDataContext)
        {
            _ProductDataContext = productSqlDataContext;
        }

        public async Task<ProductEntityDomain> CreateProductAsync(ProductEntityDomain product)
        {
            await _ProductDataContext.Connection.OpenAsync();
            using (var trans = _ProductDataContext.Connection.BeginTransaction())
            {
                try
                {
                    await _ProductDataContext.Connection.InsertAsync(ProductEntityData.ToEntityData(product), trans);
                    trans.Commit();
                    _ProductDataContext.Connection.Close();
                }
                catch (System.Exception ex)
                {
                    trans.Rollback();
                    _ProductDataContext.Connection.Close();
                }
            }

            return product;
        }

        public async Task<List<ProductEntityDomain>> GetAllProductAsync()
        {
            var resultData = await _ProductDataContext.Connection.GetAllAsync<ProductEntityData>();
            return resultData.Select(r => ProductEntityData.ToEntityDomain(r)).ToList();
        }

        public async Task<ProductEntityDomain> GetProductAsync(string id)
        {
            var resultData = await _ProductDataContext.Connection.GetAsync<ProductEntityData>(id);
            return ProductEntityData.ToEntityDomain(resultData);
        }

        public async Task<bool> RemoveProductAsync(string id)
        {
            var resultData = await _ProductDataContext.Connection.ExecuteAsync("Delete From Product Where Id @Id", new { Id = id}) ;

            return resultData == 1;
        }

        public async Task<bool> UpdateProductAsync(ProductEntityDomain product)
        {
            var resultUpdate = await _ProductDataContext.Connection.UpdateAsync<ProductEntityData>(ProductEntityData.ToEntityData(product));

            return resultUpdate;
        }
    }
}