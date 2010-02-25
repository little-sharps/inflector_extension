namespace inflector_extension.Inflector
{
    internal interface IReplacementRule : IRuleApplier
    {
        string Replacement { get; }
        string Pattern { get; }
    }
}