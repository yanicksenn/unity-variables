using UnityEngine;
using Variables.Floats;
using Variables.Runtime;

namespace Variables.Ints
{
    [CreateAssetMenu(
        menuName = VariableConstants.IntMenu + "/Create int variable", 
        fileName = "IntVariable",
        order = 1)]
    public class IntVariable : AbstractVariable<int, IntEvent>, INumberContainer<int>
    {
        [SerializeField, Space]
        private IntEvent onChangeEvent = new IntEvent();
        public override IntEvent OnChangeEvent => onChangeEvent;
        
        public void Inv() => SetValue(-GetValue());
        public void Inc() => SetValue(GetValue() + 1);
        public void Dec() => SetValue(GetValue() - 1);
        public void Add(int value) => SetValue(GetValue() + value);
        public void Sub(int value) => SetValue(GetValue() - value);
        public void Mul(int value) => SetValue(GetValue() * value);
        public void Div(int value) => SetValue(GetValue() / value);
    }
}