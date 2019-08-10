using ProductBoundedContext.Domain.EntityDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductBoundedContext.Domain.UseCases.Interfaces
{
    public interface ICreateProduct
    {
        Task<ResponseResult<ProductEntityDomain>> InvokeAsync(ProductEntityDomain productEntityDomain);
    }
}
