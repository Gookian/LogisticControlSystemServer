using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageStateController : GenericApiController<PackageState>
    {
        public PackageStateController(IRepository<PackageState> repository) : base(repository)
        {
        }
    }
}
