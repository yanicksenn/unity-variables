namespace CraipaiGames.Variables.Editor
{
    public abstract class AbstractSimpleReferenceDrawer : AbstractReferenceDrawer
    {
        protected override string GetUseConstantPropertyName()
        {
            return "useConstant";
        }

        protected override string GetConstantPropertyName()
        {
            return "constant";
        }

        protected override string GetVariablePropertyName()
        {
            return "variable";
        }
    }
}