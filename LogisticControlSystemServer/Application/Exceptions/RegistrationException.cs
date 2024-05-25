using LogisticControlSystemServer.Application.Enums;
using LogisticControlSystemServer.Utils.Extensions;

namespace LogisticControlSystemServer.Application.Exceptions
{
    public class RegistrationException : Exception
    {
        public override string Message { get { return _message; } }
        public int StatusCode { get; set; }

        private string _message;

        public RegistrationException(RegistrationError error) : base("")
        {
            StatusCode = (int)error;

            _message = error.DisplayName();
        }
    }
}
