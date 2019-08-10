using Microsoft.AspNetCore.Mvc;
using ProductBoundedContext.Domain;
using ProductBoundedContext.Domain.EntityDomain;
using ProductBoundedContext.Domain.UseCases.Interfaces;
using ProductBoundedContext.Service.Controllers.v1.ValueObjects;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProductBoundedContext.Service.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")] // http://rrsantos.com.br/api/products/v1/endpoint
    public class ProductsController : ControllerBase
    {
        // Inserção, Criação, etc. --> HTTP POST
        // Atualização --> HTTP PUT
        // Delete, Exclusão --> DELETE
        // Seleção, retorno de dados, select, etc. --> HTTP GET

        /// <summary>
        /// Este endpoint Cria um produto
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///     POST /api/products/v1
        /// </remarks>
        /// <param name="createProductRequest"></param>
        /// <param name="createProduct"></param>
        /// <returns>Produto criado.</returns>
        /// <response code="201">201 - Success Created</response>
        /// <response code="400">400 - BadRequest</response>
        /// <response code="500">500 - Internal Server Error</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseResult<ProductEntityDomain>), 201)]
        [ProducesResponseType(typeof(ResponseResult<ProductEntityDomain>), 400)]
        public async Task<ActionResult> Post([FromBody]CreateProductRequest createProductRequest, [FromServices]ICreateProduct createProduct)
        {
            try
            {
                ResponseResult<ProductEntityDomain> resultDomain = await createProduct.InvokeAsync(new ProductEntityDomain()
                {
                    Description = createProductRequest.Description,
                    BarCode = createProductRequest.BarCode,
                    UnitMeasurementId = createProductRequest.UnitMeasurementId
                });

                if (!resultDomain.Success)
                {
                    return BadRequest(resultDomain); // Retorna 400 BadRequest
                }

                return Created("Product", resultDomain); // Retorna 201 Success Created
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(500); // Retorna 500 Internal Server Error.
            }
        }


    }
}