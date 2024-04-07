using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryPointController : GenericApiController<DeliveryPoint>
    {
        public DeliveryPointController(IRepository<DeliveryPoint> repository) : base(repository)
        {
        }
    }
}
