using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : GenericApiController<Delivery>
    {
        public DeliveryController(IRepository<Delivery> repository) : base(repository)
        {
        }

        public override ActionResult<IEnumerable<Delivery>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetWithInclude(
                x => x.Warehouse,
                y => y.DeliveryPoint,
                z => z.Package,
                w => w.Flight);

            return Ok(entities);
        }

        public override ActionResult<Delivery> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.DeliveryPointId == id,
                y => y.Warehouse,
                z => z.DeliveryPoint,
                w => w.Package,
                v => v.Flight)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
