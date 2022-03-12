using UnityEngine;
using Variables.Runtime;

namespace Variables.Floats
{
    /// <summary>
    /// Float variable wrapped in a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(
        menuName = VariableConstants.FloatMenu + "/Create float variable", 
        fileName = "FloatVariable",
        order = 1)]
    public class FloatVariable : AbstractVariable<float, FloatEvent>, INumberContainer<float>
    {
        [SerializeField, Space]
        private FloatEvent onChangeEvent = new FloatEvent();
        public override FloatEvent OnChangeEvent => onChangeEvent;
        
        public void Inv() => SetValue(-GetValue());
        public void Inc() => SetValue(GetValue() + 1);
        public void Dec() => SetValue(GetValue() - 1);
        public void Add(float value) => SetValue(GetValue() + value);
        public void Sub(float value) => SetValue(GetValue() - value);
        public void Mul(float value) => SetValue(GetValue() * value);
        public void Div(float value) => SetValue(GetValue() / value);
    }
}
