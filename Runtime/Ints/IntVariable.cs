using UnityEngine;
using Variables.unity_variables.Runtime;

namespace Variables.Ints
{
    [CreateAssetMenu(menuName = VariableConstants.RootMenu + "/Create int variable", fileName = "IntVariable")]
    public class IntVariable : AbstractVariable<int>, IMathOperations<int>
    {
        public void Inv() => SetValue(-GetValue());
        public void Inc() => SetValue(GetValue() + 1);
        public void Dec() => SetValue(GetValue() - 1);
        public void Add(int value) => SetValue(GetValue() + value);
        public void Sub(int value) => SetValue(GetValue() - value);
        public void Mul(int value) => SetValue(GetValue() * value);
        public void Div(int value) => SetValue(GetValue() / value);
    }
}