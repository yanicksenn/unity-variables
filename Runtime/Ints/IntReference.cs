using System;
using Variables.Floats;
using Variables.Runtime;

namespace Variables.Ints
{
    [Serializable]
    public class IntReference : AbstractReference<int, IntVariable, IntEvent>, INumberContainer<int>
    {
        public IntReference(int defaultConstantValue = 0) : base(defaultConstantValue)
        {
        }
        
        public void Inv() => SetValue(-GetValue());
        public void Inc() => SetValue(GetValue() + 1);
        public void Dec() => SetValue(GetValue() - 1);
        public void Add(int value) => SetValue(GetValue() + value);
        public void Sub(int value) => SetValue(GetValue() - value);
        public void Mul(int value) => SetValue(GetValue() * value);
        public void Div(int value) => SetValue(GetValue() / value);
    }
}