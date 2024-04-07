using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : GenericApiController<Order>
    {
        public OrderController(IRepository<Order> repository) : base(repository)
        {
        }
    }
}
