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
    public class ProductDataController : GenericApiController<ProductData>
    {
        private IHubContext<ProductDataNotificationHub> _hubContext;

        public ProductDataController(IRepository<ProductData> repository, IHubContext<ProductDataNotificationHub> hubContext) : base(repository)
        {
            _hubContext = hubContext;
        }

        public override ActionResult<ProductData> Create([FromBody] ProductData toCreate)
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

        public override ActionResult<ProductData> Update(int id, [FromBody] ProductData toUpdate)
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

        public override ActionResult<ProductData> Delete(int id)
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
    }
}
