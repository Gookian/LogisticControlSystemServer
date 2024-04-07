using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInWarehouseController : GenericApiController<ProductInWarehouse>
    {
        public ProductInWarehouseController(IRepository<ProductInWarehouse> repository) : base(repository)
        {
        }

        public override ActionResult<IEnumerable<ProductInWarehouse>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetWithInclude(
                x => x.Product,
                y => y.Warehouse);

            return Ok(entities);
        }

        public override ActionResult<ProductInWarehouse> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.ProductInWarehouseId == id,
                y => y.Product,
                z => z.Warehouse)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
