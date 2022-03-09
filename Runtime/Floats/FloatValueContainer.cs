using UnityEngine;
using Variables.unity_variables.Runtime;

namespace Variables.Floats
{
    [CreateAssetMenu(menuName = VariableConstants.RootMenu + "/Create float variable", fileName = "FloatVariable")]
    public class FloatValueContainer : AbstractValueContainer<float>, IMathOperations<float>
    {
        [SerializeField, Space]
        private FloatEvent onChangeEvent = new FloatEvent();
        public FloatEvent OnChangeEvent => onChangeEvent;
        
        public void Inv() => SetValue(-GetValue());
        public void Inc() => SetValue(GetValue() + 1);
        public void Dec() => SetValue(GetValue() - 1);
        public void Add(float value) => SetValue(GetValue() + value);
        public void Sub(float value) => SetValue(GetValue() - value);
        public void Mul(float value) => SetValue(GetValue() * value);
        public void Div(float value) => SetValue(GetValue() / value);
        
        [ContextMenu("Invoke change event")]
        public void InvokeChangeEvent()
        {
            OnChangeEvent.Invoke(GetValue());
        }
        
        protected override void OnChange(float oldValue, float newValue)
        {
            OnChangeEvent.Invoke(newValue);
        }
    }
}
