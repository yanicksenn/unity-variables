using System;
using Variables.unity_variables.Runtime;

namespace Variables.Floats
{
    /// <summary>
    /// Float reference allowing to switch between constant and variable.
    /// </summary>
    [Serializable]
    public class FloatReference : AbstractReference<float, FloatValueContainer>, IMathOperations<float>
    {
        public FloatReference(float defaultConstantValue = 0.0f) : base(defaultConstantValue)
        {
        }
        
        public void Inv() => SetValue(-GetValue());
        public void Inc() => SetValue(GetValue() + 1);
        public void Dec() => SetValue(GetValue() - 1);
        public void Add(float value) => SetValue(GetValue() + value);
        public void Sub(float value) => SetValue(GetValue() - value);
        public void Mul(float value) => SetValue(GetValue() * value);
        public void Div(float value) => SetValue(GetValue() / value);
    }
}