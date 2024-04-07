using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;

namespace LogisticControlSystemServer.Utils.Extensions
{
    public static class EnumExtensions
    {
        private static readonly
            ConcurrentDictionary<string, string> DisplayNameCache = new ConcurrentDictionary<string, string>();

        public static string DisplayName(this Enum value)
        {
            var key = $"{value.GetType().FullName}.{value}";

            var displayName = DisplayNameCache.GetOrAdd(key, x =>
            {
                DescriptionAttribute[] name;
                var field = value
                    .GetType()
                    .GetTypeInfo()
                    .GetField(value.ToString());

                if (field != null)
                {
                    name = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    return name.Length > 0 ? name[0].Description : value.ToString();
                }
                else
                {
                    return value.ToString();
                }
            });

            return displayName;
        }
    }
}