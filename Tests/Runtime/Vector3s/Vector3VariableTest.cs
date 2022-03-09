using Variables.Vector3s;
using UnityEngine;

namespace Variables.Tests.Vector3s
{
    public class Vector3VariableTest : AbstractValueContainerTest<Vector3, Vector3Variable>
    {
        protected override Vector3Variable CreateValueContainer() => ScriptableObject.CreateInstance<Vector3Variable>();
        protected override Vector3 CreateRandomValue() => Random.insideUnitCircle;
    }
}
