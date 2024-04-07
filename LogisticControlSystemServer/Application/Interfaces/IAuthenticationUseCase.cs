namespace LogisticControlSystemServer.Application.Interfaces
{
    public interface IAuthenticationUseCase
    {
        Guid Invoke(string username, string password);
    }
}
