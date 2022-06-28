using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimulateTheWorld.Core.Reflection;

public static class TypeGetter
{
    public static T[] GetInstancesAssignableFromType<T>()
    {
        List<T> instances = new List<T>();

        foreach (Type type in Assembly.GetCallingAssembly().GetTypes())
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