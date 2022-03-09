using Variables.Bools;
using UnityEngine;

namespace Variables.Tests.Bools
{
    public class BoolVariableTest : AbstractVariableTest<bool>
    {
        protected override IVariable<bool> CreateVariable() => ScriptableObject.CreateInstance<BoolVariable>();

        protected override bool CreateRandomValue() => Random.Range(0, 1) == 0;
    }
}
