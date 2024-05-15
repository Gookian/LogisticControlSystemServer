using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.SignalR;
using WebApplicationServer.Presentation.Enums;
using WebApplicationServer.Presentation.Habs;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : GenericApiController<Product>
    {
        private IHubContext<ProductNotificationHub> _hubContext;

        public ProductController(IRepository<Product> repository, IHubContext<ProductNotificationHub> hubContext) : base(repository)
        {
            _hubContext = hubContext;
        }

        public override ActionResult<Product> Create([FromBody] Product toCreate)
        {
            ActionResult<Product> result = base.Create(toCreate);

            if (result.Result is OkObjectResult)
            {
                var product = (result.Result as OkObjectResult)?.Value as Product;

                if (product != null)
                {
                    var productResult = GetOne(product.ProductId);
                    var productWithInclude = (productResult.Result as OkObjectResult)?.Value as Product;

                    _hubContext.Clients.All.SendAsync("NotificationCallback", productWithInclude, UpdateType.Add);

                    return productResult;
                }
            }

            return result;
        }

        public override ActionResult<Product> Update(int id, [FromBody] Product toUpdate)
        {
            ActionResult<Product> result = base.Update(id, toUpdate);
            ActionResult<Product> productResult = GetOne(id);

            if (productResult.Result is OkObjectResult && result.Result is OkObjectResult)
            {
                var productWithInclude = (productResult.Result as OkObjectResult)?.Value as Product;

                _hubContext.Clients.All.SendAsync("NotificationCallback", productWithInclude, UpdateType.Update);

                return productResult;
            }

            return result;
        }

        public override ActionResult<Product> Delete(int id)
        {
            ActionResult<Product> productResult = GetOne(id);
            ActionResult<Product> result = base.Delete(id);

            if (productResult.Result is OkObjectResult && result.Result is OkObjectResult)
            {
                var productWithInclude = (productResult.Result as OkObjectResult)?.Value as Product;

                _hubContext.Clients.All.SendAsync("NotificationCallback", productWithInclude, UpdateType.Delete);

                return productResult;
            }

            return result;
        }

        public override ActionResult<IEnumerable<Product>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetWithInclude(
                x => x.ProductData,
                y => y.ProductState);

            return Ok(entities);
        }

        public override ActionResult<Product> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.ProductId == id,
                y => y.ProductData,
                z => z.ProductState)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
