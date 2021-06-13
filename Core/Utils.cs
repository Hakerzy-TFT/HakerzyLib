using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakerzyLib.Core
{
    public static class Utils
    {
        public static bool IsAnyNullOrEmpty(object obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return true;

            return obj.GetType().GetProperties()
                .Any(x => IsNullOrEmpty(x.GetValue(obj)));
        }

        private static bool IsNullOrEmpty(object value)
        {
            if (Object.ReferenceEquals(value, null))
                return true;

            var type = value.GetType();
            return type.IsValueType
                && Object.Equals(value, Activator.CreateInstance(type));

        }
    }
}
