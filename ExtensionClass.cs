using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_SubArray_Value
{
    public static class ExtensionClass
    {
        public static bool ContainsDuplicates<T>(this IEnumerable<T> enumerable)
        {
            HashSet<T> set = new HashSet<T>();
            foreach (T item in enumerable)
            {
                if (!set.Add(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
