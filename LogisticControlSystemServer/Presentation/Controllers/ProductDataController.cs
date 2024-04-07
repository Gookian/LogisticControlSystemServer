using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDataController : GenericApiController<ProductData>
    {
        public ProductDataController(IRepository<ProductData> repository) : base(repository)
        {
        }
    }
}
