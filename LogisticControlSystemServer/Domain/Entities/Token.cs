namespace LogisticControlSystemServer.Domain.Entities
{
    public class Token
    {
        public Guid Value { get; set; }
        public DateTime Lifetime { get; set; }
        public DateTime CurrentLifetime { get; set; }
        public User User { get; set; }

        public Token(User user, int hours, int minutes, int seconds)
        {
            Value = Guid.NewGuid();
            Lifetime = new DateTime(1, 1, 1, hours, minutes, seconds);
            CurrentLifetime = new DateTime(1, 1, 1, 0, 0, 0);
            User = user;
        }
    }
}
