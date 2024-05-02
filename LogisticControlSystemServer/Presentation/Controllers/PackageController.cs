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
    public class PackageController : GenericApiController<Package>
    {
        private IHubContext<PackageNotificationHub> _hubContext;

        public PackageController(IRepository<Package> repository, IHubContext<PackageNotificationHub> hubContext) : base(repository)
        {
            _hubContext = hubContext;
        }


        public override ActionResult<Package> Create([FromBody] Package toCreate)
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

        public override ActionResult<Package> Update(int id, [FromBody] Package toUpdate)
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

        public override ActionResult<Package> Delete(int id)
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

        public override ActionResult<IEnumerable<Package>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetWithInclude(
                x => x.PackageState);

            return Ok(entities);
        }

        public override ActionResult<Package> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.PackageId == id,
                y => y.PackageState)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
