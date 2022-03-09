using Variables.Vector3s;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Vector3s
{
    [UsedImplicitly]
    public class Vector3ValueContainerTest : AbstractValueContainerTest<Vector3>
    {
        protected override IValueContainer<Vector3> CreateVariable() => ScriptableObject.CreateInstance<Vector3ValueContainer>();
        protected override Vector3 CreateRandomValue() => Random.insideUnitSphere;
    }
}