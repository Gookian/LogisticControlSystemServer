namespace LogisticControlSystemServer.Application.Interfaces
{
    public interface IRegistrationUseCase
    {
        void Invoke(string username, string password);
    }
}
