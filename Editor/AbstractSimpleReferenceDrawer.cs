using UnityEditor;

namespace CraipaiGames.Variables.Editor
{
    public abstract class AbstractSimpleReferenceDrawer : AbstractReferenceDrawer
    {
        protected override SerializedProperty GetSwitchProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative("useConstant");
        }

        protected override SerializedProperty GetConstantProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative("constant");
        }

        protected override SerializedProperty GetVariableProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative("variable");
        }
    }
}