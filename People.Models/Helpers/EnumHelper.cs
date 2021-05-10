using System;
using System.Linq;

namespace People.Models.Helpers
{
    public static class EnumHelper
    {

        public static T Parse<T>(string value)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(nameof(T));
            return (T)Enum.Parse(typeof(T), value);
        }

        public static T[] ToArray<T>(params T[] excluded)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(nameof(T));
            return Enum.GetValues(typeof(T)).Cast<T>().Where(x => !excluded.Contains(x)).ToArray();
        }
    }
}
