using Microsoft.AspNetCore.Mvc;
using LogisticControlSystemServer.Application.Exceptions;
using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Presentation.Models;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationUseCase _useCase;

        public AuthenticationController(IAuthenticationUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public ActionResult Get(string username, string password)
        {
            try
            {
                Guid token = _useCase.Invoke(username, password);

                return Ok(token);
            }
            catch (AuthenticationException e)
            {
                return NotFound(new ErrorModel(e.StatusCode, e.Message));
            }
        }
    }
}
