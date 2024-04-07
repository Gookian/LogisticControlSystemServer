using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : GenericApiController<Flight>
    {
        public FlightController(IRepository<Flight> repository) : base(repository)
        {
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
