using Microsoft.AspNetCore.Mvc;
using LogisticControlSystemServer.Application.Exceptions;
using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Presentation.Models;
using LogisticControlSystemServer.Application.UseCases;

namespace LogisticControlSystemServer.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationUseCase _authenticationUseCase;
        private IRemoveAuthenticationUseCase _removeAuthenticationUseCase;

        public AuthenticationController(IAuthenticationUseCase authenticationUseCase, IRemoveAuthenticationUseCase removeAuthenticationUseCase)
        {
            _authenticationUseCase = authenticationUseCase;
            _removeAuthenticationUseCase = removeAuthenticationUseCase;
        }

        [HttpGet]
        public ActionResult Get(string username, string password)
        {
            try
            {
                Guid token = _authenticationUseCase.Invoke(username, password);

                return Ok(token);
            }
            catch (AuthenticationException e)
            {
                return NotFound(new ErrorModel(e.StatusCode, e.Message));
            }
        }

        [HttpDelete]
        public ActionResult Delete(string tokenValue)
        {
            try
            {
                _removeAuthenticationUseCase.Invoke(tokenValue);

                return Ok();
            }
            catch (AuthenticationException e)
            {
                return NotFound(new ErrorModel(e.StatusCode, e.Message));
            }
        }
    }
}
