using UnityEngine;
using Variables.Floats;

namespace Variables.Strings
{
    [CreateAssetMenu(menuName = VariableConstants.RootMenu + "/Create string variable", fileName = "StringVariable")]
    public class StringVariable : AbstractVariable<string, StringEvent>
    {
        [SerializeField, Space]
        private StringEvent onChangeEvent = new StringEvent();
        public override StringEvent OnChangeEvent => onChangeEvent;
    }
}