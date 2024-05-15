namespace LogisticControlSystemServer.Domain.Entities.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateAttribute : Attribute
    {
        public string Pattern { get; }
        public int MaxLength { get; }
        public int MinLength { get; }

        public ValidateAttribute(string pattern, int maxLength = 1, int minLength = 1)
        {
            Pattern = pattern;
            MinLength = minLength;
            MaxLength = maxLength;
        }
    }
}
