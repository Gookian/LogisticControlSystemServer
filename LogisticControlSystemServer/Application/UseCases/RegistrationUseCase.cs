using LogisticControlSystemServer.Application.Enums;
using LogisticControlSystemServer.Application.Exceptions;
using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;

namespace LogisticControlSystemServer.Application.UseCases
{
    public class RegistrationUseCase : IRegistrationUseCase
    {
        private IRepository<User> _repository;

        public RegistrationUseCase(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Invoke(string username, string password)
        {
            var user = _repository
                .Get(x => x.Username == username)
                .FirstOrDefault();

            if (user == null)
            {
                var createUser = new User
                {
                    UserId = 0,
                    Username = username,
                    Password = password
                };
                _repository.Create(createUser);
            }
            else
            {
                throw new RegistrationException(RegistrationError.UserExists);
            }
        }
    }
}
