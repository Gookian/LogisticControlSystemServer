using System.Timers;
using LogisticControlSystemServer.Domain.Entities;

namespace LogisticControlSystemServer.Application
{
    public class TokenManager
    {
        private List<Token> tokens = new List<Token>();

        public TokenManager(ILoggerFactory loggerFactory)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += UpdateTokens;
            timer.Enabled = true;
        }

        public bool TokenExists(Guid token)
        {
            var item = tokens.FirstOrDefault(x => x.Value == token);

            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Guid CreateToken(User user)
        {
            var existingTokenUser = tokens.FirstOrDefault(x => x.User.UserId == user.UserId);

            if (existingTokenUser == null)
            {
                Token token = new Token(user, 3, 5, 30);
                tokens.Add(token);

                return token.Value;
            }
            else
            {
                return existingTokenUser.Value;
            }
        }

        public void RemoveToken(string tokenValue)
        {
            Guid guid = new Guid();
            bool valid = Guid.TryParse(tokenValue, out guid);

            if (valid)
            {
                Token? token = tokens.FirstOrDefault(x => x.Value == guid);

                if (token != null)
                {
                    tokens.Remove(token);
                }
            }
        }

        private void UpdateTokens(object? source, ElapsedEventArgs e)
        {
            List<Token> removeTokens = new List<Token>();

            foreach (var token in tokens)
            {
                token.CurrentLifetime = token.CurrentLifetime.AddSeconds(1);

                if (token.CurrentLifetime > token.Lifetime)
                {
                    removeTokens.Add(token);
                }
            }

            foreach (var token in removeTokens)
            {
                tokens.Remove(token);
            }
            removeTokens.Clear();
        }
    }
}