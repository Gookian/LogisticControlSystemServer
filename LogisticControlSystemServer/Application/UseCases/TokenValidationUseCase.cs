using LogisticControlSystemServer.Application.Interfaces;

namespace LogisticControlSystemServer.Application.UseCases
{
    public class TokenValidationUseCase : ITokenValidationUseCase
    {
        private TokenManager _tokenManager;

        public TokenValidationUseCase(TokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public bool Invoke(Guid token)
        {
            return _tokenManager.TokenExists(token);
        }
    }
}
