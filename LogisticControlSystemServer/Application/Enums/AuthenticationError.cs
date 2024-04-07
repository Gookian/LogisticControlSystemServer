using System.ComponentModel;

namespace LogisticControlSystemServer.Application.Enums
{
    public enum AuthenticationError
    {
        [Description("Ошибка аутентификации: пользователь не найден или неверные учетные данные.")]
        InvalidCredentials = 1,
    }
}
