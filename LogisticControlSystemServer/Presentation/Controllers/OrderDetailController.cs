using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : GenericApiController<OrderDetail>
    {
        public OrderDetailController(IRepository<OrderDetail> repository) : base(repository)
        {
        }

        public override ActionResult<IEnumerable<OrderDetail>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetWithInclude(
                x => x.Order,
                y => y.ProductData);

            return Ok(entities);
        }

        public override ActionResult<OrderDetail> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.OrderDetailId == id,
                y => y.Order,
                z => z.ProductData)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
