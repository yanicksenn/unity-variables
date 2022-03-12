namespace Variables.Editor
{
    /// <summary>
    /// Abstract property drawer for properties based on AbstractReference.
    /// </summary>
    public abstract class AbstractSimpleReferenceDrawer : AbstractReferenceDrawer
    {
        protected override string GetUseConstantPropertyName() => "useConstant";
        protected override string GetConstantPropertyName() => "constant";
        protected override string GetVariablePropertyName() => "variable";
    }
}