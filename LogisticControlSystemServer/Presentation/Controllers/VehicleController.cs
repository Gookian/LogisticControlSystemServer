using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : GenericApiController<Vehicle>
    {
        public VehicleController(IRepository<Vehicle> repository) : base(repository)
        {
        }
    }
}
