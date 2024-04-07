using LogisticControlSystemServer.Application.Enums;
using LogisticControlSystemServer.Utils.Extensions;

namespace LogisticControlSystemServer.Application.Exceptions
{
    public class AuthenticationException : Exception
    {
        public override string Message { get { return _message; } }
        public int StatusCode { get; set; }

        private string _message;

        public AuthenticationException(AuthenticationError error, Exception innerException) : base("", innerException)
        {
            StatusCode = (int)error;

            _message = error.DisplayName();
        }
    }
}
