using Variables.Vector2s;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Vector2s
{
    [UsedImplicitly]
    public class Vector2VariableTest : AbstractVariableTest<Vector2>
    {
        protected override IVariable<Vector2> CreateVariable() => ScriptableObject.CreateInstance<Vector2Variable>();

        protected override Vector2 CreateRandomValue() => Random.insideUnitCircle;
    }
}
