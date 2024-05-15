using LogisticControlSystemServer.Application.Enums;
using LogisticControlSystemServer.Application.Exceptions;
using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;

namespace LogisticControlSystemServer.Application.UseCases
{
    public class RemoveAuthenticationUseCase : IRemoveAuthenticationUseCase
    {
        private TokenManager _tokenManager;

        public RemoveAuthenticationUseCase(TokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public void Invoke(string tokenValue)
        {
            _tokenManager.RemoveToken(tokenValue);
        }
    }
}
