using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplicationServer.Presentation.Enums;
using WebApplicationServer.Presentation.Habs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            ActionResult<Package> result = base.Create(toCreate);

            if (result.Result is OkObjectResult)
            {
                var package = (result.Result as OkObjectResult)?.Value as Package;

                if (package != null)
                {
                    var packageResult = GetOne(package.PackageId);
                    var packageWithInclude = (packageResult.Result as OkObjectResult)?.Value as Package;

                    _hubContext.Clients.All.SendAsync("NotificationCallback", packageWithInclude, UpdateType.Add);

                    return packageResult;
                }
            }

            return result;
        }

        public override ActionResult<Package> Update(int id, [FromBody] Package toUpdate)
        {
            ActionResult<Package> result = base.Update(id, toUpdate);
            ActionResult<Package> packageResult = GetOne(id);

            if (packageResult.Result is OkObjectResult && result.Result is OkObjectResult)
            {
                var packageWithInclude = (packageResult.Result as OkObjectResult)?.Value as Package;

                _hubContext.Clients.All.SendAsync("NotificationCallback", packageWithInclude, UpdateType.Update);

                return packageResult;
            }

            return result;
        }

        public override ActionResult<Package> Delete(int id)
        {
            ActionResult<Package> packageResult = GetOne(id);
            ActionResult<Package> result = base.Delete(id);

            if (packageResult.Result is OkObjectResult && result.Result is OkObjectResult)
            {
                var packageWithInclude = (packageResult.Result as OkObjectResult)?.Value as Package;

                _hubContext.Clients.All.SendAsync("NotificationCallback", packageWithInclude, UpdateType.Delete);

                return packageResult;
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
