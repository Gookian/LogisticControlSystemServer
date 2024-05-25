using Microsoft.AspNetCore.Mvc;
using LogisticControlSystemServer.Application.Exceptions;
using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Presentation.Models;
using LogisticControlSystemServer.Application.UseCases;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationUseCase _registrationUseCase;

        public RegistrationController(IRegistrationUseCase registrationUseCase)
        {
            _registrationUseCase = registrationUseCase;
        }

        [HttpPost]
        public ActionResult Post([FromBody] RegistrationCredentials credentials)
        {
            try
            {
                _registrationUseCase.Invoke(credentials.Username, credentials.Password);

                return Ok();
            }
            catch (RegistrationException e)
            {
                return Conflict(new ErrorModel(e.StatusCode, e.Message));
            }
        }
    }

    public class RegistrationCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}