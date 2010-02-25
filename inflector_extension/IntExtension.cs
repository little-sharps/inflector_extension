using System;
using inflector_extension;
using inflector_extension.Inflector;

// ReSharper disable CheckNamespace

public static class InflectorInt32Extension
{
    private static readonly IInflector Inflector = new EnglishInflector();

    public static FluentNumberInflector InflectTo(this Int32 value)
    {
        return new FluentNumberInflector(value, Inflector);
    }
}
public static class InflectorInt16Extension
{
    private static readonly IInflector Inflector = new EnglishInflector();

    public static FluentNumberInflector InflectTo(this Int16 value)
    {
        return new FluentNumberInflector(value, Inflector);
    }
}
public static class InflectorInt64Extension
{
    private static readonly IInflector Inflector = new EnglishInflector();

    public static FluentNumberInflector InflectTo(this Int64 value)
    {
        return new FluentNumberInflector(value, Inflector);
    }
}

// ReSharper restore CheckNamespace