using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStateController : GenericApiController<ProductState>
    {
        public ProductStateController(IRepository<ProductState> repository) : base(repository)
        {
        }
    }
}
