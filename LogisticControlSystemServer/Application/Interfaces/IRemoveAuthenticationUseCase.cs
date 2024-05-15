namespace LogisticControlSystemServer.Application.Interfaces
{
    public interface IRemoveAuthenticationUseCase
    {
        void Invoke(string tokenValue);
    }
}
