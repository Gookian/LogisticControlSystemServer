using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : GenericApiController<Product>
    {
        public ProductController(IRepository<Product> repository) : base(repository)
        {
        }

        public override ActionResult<IEnumerable<Product>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entities = repository.GetWithInclude(
                x => x.ProductData,
                y => y.ProductState);

            return Ok(entities);
        }

        public override ActionResult<Product> GetOne(int id)
        {
            var foundEntity = repository.GetWithInclude(
                x => x.ProductId == id,
                y => y.ProductData,
                z => z.ProductState)
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return NotFound();
            }

            return Ok(foundEntity);
        }
    }
}
