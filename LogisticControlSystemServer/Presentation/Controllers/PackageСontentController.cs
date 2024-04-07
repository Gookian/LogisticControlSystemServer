using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageСontentController : GenericApiController<PackageСontent>
    {
        public PackageСontentController(IRepository<PackageСontent> repository) : base(repository)
        {
        }

        public override ActionResult<IEnumerable<PackageСontent>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetWithInclude(
                x => x.Product,
                y => y.Package);

            return Ok(entities);
        }

        public override ActionResult<PackageСontent> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.PackageСontentId == id,
                y => y.Product,
                z => z.Package)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
