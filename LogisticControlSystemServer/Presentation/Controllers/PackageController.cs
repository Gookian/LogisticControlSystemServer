using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : GenericApiController<Package>
    {
        public PackageController(IRepository<Package> repository) : base(repository)
        {
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
