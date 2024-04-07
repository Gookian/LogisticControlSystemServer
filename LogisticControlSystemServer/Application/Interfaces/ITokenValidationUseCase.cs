namespace LogisticControlSystemServer.Application.Interfaces
{
    public interface ITokenValidationUseCase
    {
        bool Invoke(Guid token);
    }
}
