using Variables.Bools;
using UnityEngine;

namespace Variables.Tests.Bools
{
    public class BoolVariableTest : AbstractVariableTest<bool>
    {
        protected override AbstractVariable<bool> CreateVariable() => ScriptableObject.CreateInstance<BoolVariable>();

        protected override bool GetValue() => true;
    }
}
