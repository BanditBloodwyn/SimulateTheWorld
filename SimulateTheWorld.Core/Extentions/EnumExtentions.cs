using System;

namespace SimulateTheWorld.Core.Extentions;

public static class EnumExtentions
{
    private static readonly Random _Random = new(Environment.TickCount);

    public static T RandomOf<T>() where T : IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new InvalidOperationException("Must use Enum type");

        Array enumValues = Enum.GetValues(typeof(T));
        return (T)enumValues.GetValue(_Random.Next(enumValues.Length))! ?? throw new InvalidOperationException();
    }
}