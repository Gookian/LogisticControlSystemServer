using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            var result = base.Create(toCreate);

            if (result != null)
            {
                var okObjectResult = (OkObjectResult)(result.Result);

                if (okObjectResult != null)
                {
                    _hubContext.Clients.All.SendAsync("NotificationCallback", okObjectResult.Value, UpdateType.Add);
                }
            }

            return result;
        }

        public override ActionResult<Product> Update(int id, [FromBody] Product toUpdate)
        {
            var result = base.Update(id, toUpdate);

            if (result != null)
            {
                var okObjectResult = (OkObjectResult)(result.Result);

                if (okObjectResult != null)
                {
                    _hubContext.Clients.All.SendAsync("NotificationCallback", okObjectResult.Value, UpdateType.Update);
                }
            }

            return result;
        }

        public override ActionResult<Product> Delete(int id)
        {
            var result = base.Delete(id);

            if (result != null)
            {
                var okObjectResult = (OkObjectResult)(result.Result);

                if (okObjectResult != null)
                {
                    _hubContext.Clients.All.SendAsync("NotificationCallback", okObjectResult.Value, UpdateType.Delete);
                }
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
