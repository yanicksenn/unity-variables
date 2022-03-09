using Variables.Vector3s;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Vector3s
{
    [UsedImplicitly]
    public class Vector3VariableTest : AbstractVariableTest<Vector3>
    {
        protected override IVariable<Vector3> CreateVariable() => ScriptableObject.CreateInstance<Vector3Variable>();
        protected override Vector3 CreateRandomValue() => Random.insideUnitSphere;
    }
}
