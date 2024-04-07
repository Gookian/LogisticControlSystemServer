using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : GenericApiController<Warehouse>
    {
        public WarehouseController(IRepository<Warehouse> repository) : base(repository)
        {
        }
    }
}
