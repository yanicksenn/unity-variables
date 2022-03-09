using Variables.Vector2s;
using UnityEngine;

namespace Variables.Tests.Vector2s
{
    public class Vector2VariableTest : AbstractValueContainerTest<Vector2, Vector2Variable>
    {
        protected override Vector2Variable CreateValueContainer() => ScriptableObject.CreateInstance<Vector2Variable>();
        protected override Vector2 CreateRandomValue() => Random.insideUnitCircle;
    }
}
