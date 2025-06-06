using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAnalyser.Helper
{
    public static class ConvertHelper
    {
        public static List<T> FindCommands<T>(Assembly assembly)
        {
            var cobolCommands = assembly?.GetTypes()
                ?.Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface)
                ?.Select(type => (T)Activator.CreateInstance(type))
                ?.ToList();

            return cobolCommands ?? new List<T?>();
        }
    }
}
