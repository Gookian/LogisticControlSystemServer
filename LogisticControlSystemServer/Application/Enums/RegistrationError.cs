using System.ComponentModel;

namespace LogisticControlSystemServer.Application.Enums
{
    public enum RegistrationError
    {
        [Description("Ошибка регистрации: пользователь с такими учетными данными уже существует.")]
        UserExists = 1,
    }
}
