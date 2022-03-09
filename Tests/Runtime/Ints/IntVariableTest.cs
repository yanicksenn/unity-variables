using Variables.Ints;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Ints
{
    [UsedImplicitly]
    public class IntVariableTest : AbstractValueContainerTest<int, IntVariable>
    {
        protected override IntVariable CreateValueContainer() => ScriptableObject.CreateInstance<IntVariable>();
        protected override int CreateRandomValue() => Random.Range(-1000, 1000);
    }
}
