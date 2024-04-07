namespace LogisticControlSystemServer.Domain.Entities.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class StringValueAttribute : Attribute
    {
        public string Value { get; }

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
