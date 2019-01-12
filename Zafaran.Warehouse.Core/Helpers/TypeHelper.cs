using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Zafaran.Warehouse.Core.Helpers
{
    public static class TypeHelper
    {
       public  static  List<T> FindListOf<T>() where T : class
        {
            var baseType = typeof(T);
            var appAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Where(x => x.Name.StartsWith("Zafaran")).Select(Assembly.Load).ToList();
            var allFoundType = new List<T>();
            foreach (var ass in appAssemblies)
            {
                var foundTypes = ass.GetTypes()
                    .Where(x => baseType.IsAssignableFrom(x) && baseType != x && !x.IsAbstract).ToList();
                var objs = foundTypes.Select(Activator.CreateInstance)
                    .Select(x => x as T)
                    .ToList();
                allFoundType.AddRange(objs);
            }

            return allFoundType;
        }
    }
}