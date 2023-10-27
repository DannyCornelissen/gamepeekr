using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepeekrReviewManagement.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<string> EnumToList<T>()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(v => v.ToString())
                .ToList();
        }

        public static string EnumToString<T>(int Id)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            T value = (T)Enum.ToObject(typeof(T), Id);
            return value.ToString();
        }

        public static int EnumParse<T>(string value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            if (Enum.IsDefined(typeof(T), value))
            {
                return (int)Enum.Parse(typeof(T), value);
            }
            else
            {
                throw new ArgumentException("Invalid value for the enum");
            }
        }
    }
}
