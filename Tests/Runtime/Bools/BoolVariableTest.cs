using Variables.Bools;
using UnityEngine;

namespace Variables.Tests.Bools
{
    public class BoolVariableTest : AbstractValueContainerTest<bool, BoolVariable>
    {
        protected override BoolVariable CreateValueContainer() => ScriptableObject.CreateInstance<BoolVariable>();
        protected override bool CreateRandomValue() => Random.Range(0, 1) == 0;
    }
}
