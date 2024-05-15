namespace LogisticControlSystemServer.Domain.Entities.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class DescriptionAttribute : Attribute
    {
        public string Title { get; }
        public string Hint { get; }

        public DescriptionAttribute(string title, string hint)
        {
            Title = title;
            Hint = hint;
        }
    }
}
