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
    public class DeliveryPointController : GenericApiController<DeliveryPoint>
    {
        private IHubContext<DeliveryPointNotificationHub> _hubContext;

        public DeliveryPointController(IRepository<DeliveryPoint> repository, IHubContext<DeliveryPointNotificationHub> hubContext) : base(repository)
        {
            _hubContext = hubContext;
        }


        public override ActionResult<DeliveryPoint> Create([FromBody] DeliveryPoint toCreate)
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

        public override ActionResult<DeliveryPoint> Update(int id, [FromBody] DeliveryPoint toUpdate)
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

        public override ActionResult<DeliveryPoint> Delete(int id)
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
