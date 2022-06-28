using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimulateTheWorld.Core.Reflection;

public static class TypeGetter
{
    public static T[] GetInstancesAssignableFromType<T>(Assembly? assembly = null)
    {
        Type[] types = assembly == null 
            ? Assembly.GetCallingAssembly().GetTypes()
            : assembly.GetTypes();

        return GetInstancesAssignableFromTypeInternal<T>(types);
    }

    private static T[] GetInstancesAssignableFromTypeInternal<T>(Type[] types)
    {
        List<T> instances = new List<T>();

        foreach (Type type in types)
        {
            if (!typeof(T).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract)
                continue;

            ConstructorInfo? constructorInfo = type.GetConstructor(Array.Empty<Type>());
            if (constructorInfo == null)
                continue;

            instances.Add((T)constructorInfo.Invoke(null));
        }

        return instances.ToArray();
    }
}