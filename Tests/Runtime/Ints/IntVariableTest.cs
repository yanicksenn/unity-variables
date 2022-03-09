using Variables.Ints;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Ints
{
    [UsedImplicitly]
    public class IntVariableTest : AbstractVariableTest<int>
    {
        protected override IVariable<int> CreateVariable() => ScriptableObject.CreateInstance<IntVariable>();

        protected override int CreateRandomValue() => Random.Range(-1000, 1000);
    }
}
