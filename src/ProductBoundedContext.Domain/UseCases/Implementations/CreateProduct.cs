using ProductBoundedContext.Domain.EntityDomain;
using ProductBoundedContext.Domain.IRepositories;
using ProductBoundedContext.Domain.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductBoundedContext.Domain.UseCases.Implementations
{
    public class CreateProduct : ICreateProduct
    {
        private readonly IProductRepository _ProductRepository;

        public CreateProduct(IProductRepository productRepository) // Injetando a dependência de IproductRepository
        {
            _ProductRepository = productRepository;
        }

        public async Task<ResponseResult<ProductEntityDomain>> InvokeAsync(ProductEntityDomain productEntityDomain)
        {
            if (!productEntityDomain.Validate())
            {
                return ResponseResult<ProductEntityDomain>.Failed(400, "Existem campos inválidos.", productEntityDomain.Notifications);
            }

            productEntityDomain.Id = Guid.NewGuid().ToString();
            productEntityDomain.Actve = 1;
            productEntityDomain.CreatedAt = DateTime.Now;

            //var resultData = await _ProductRepository.CreateProductAsync(productEntityDomain);
            ProductEntityDomain resultData = await _ProductRepository.CreateProductAsync(productEntityDomain);

            return ResponseResult<ProductEntityDomain>.Succeeded(resultData, 201);
        }
    }
}
