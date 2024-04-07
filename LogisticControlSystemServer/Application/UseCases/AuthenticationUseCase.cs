using LogisticControlSystemServer.Application.Enums;
using LogisticControlSystemServer.Application.Exceptions;
using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;

namespace LogisticControlSystemServer.Application.UseCases
{
    public class AuthenticationUseCase : IAuthenticationUseCase
    {
        private IRepository<User> _repository;
        private TokenManager _tokenManager;

        public AuthenticationUseCase(IRepository<User> repository, TokenManager tokenManager)
        {
            _repository = repository;
            _tokenManager = tokenManager;
        }

        public Guid Invoke(string username, string password)
        {
            var user = _repository
                .Get(x => x.Username == username && x.Password == password)
                .FirstOrDefault();

            if (user != null)
            {
                return _tokenManager.CreateToken(user);
            }
            else
            {
                throw new AuthenticationException(AuthenticationError.InvalidCredentials, new ArgumentNullException());
            }
        }
    }
}
