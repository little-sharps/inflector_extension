using inflector_extension;
using inflector_extension.Inflector;

// ReSharper disable CheckNamespace
public static class InflectorStringExtension
{
    private static readonly IInflector Inflector = new EnglishInflector();

    public static FluentStringInflector Inflect(this string value) {
        return new FluentStringInflector(value, Inflector);
    }
}
// ReSharper restore CheckNamespace