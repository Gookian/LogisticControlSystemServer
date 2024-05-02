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
    public class FlightController : GenericApiController<Flight>
    {
        private IHubContext<FlightNotificationHub> _hubContext;

        public FlightController(IRepository<Flight> repository, IHubContext<FlightNotificationHub> hubContext) : base(repository)
        {
            _hubContext = hubContext;
        }

        public override ActionResult<Flight> Create([FromBody] Flight toCreate)
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

        public override ActionResult<Flight> Update(int id, [FromBody] Flight toUpdate)
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

        public override ActionResult<Flight> Delete(int id)
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

        public override ActionResult<IEnumerable<Flight>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetWithInclude(
                x => x.Vehicle);

            return Ok(entities);
        }

        public override ActionResult<Flight> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.FlightId == id,
                y => y.Vehicle)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
