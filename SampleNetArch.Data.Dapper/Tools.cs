using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleNetArch.Data.Dapper
{
    public static class Tools
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
