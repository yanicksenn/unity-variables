using Variables.Vector2s;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Vector2s
{
    [UsedImplicitly]
    public class Vector2ValueContainerTest : AbstractValueContainerTest<Vector2>
    {
        protected override IValueContainer<Vector2> CreateVariable() => ScriptableObject.CreateInstance<Vector2ValueContainer>();

        protected override Vector2 CreateRandomValue() => Random.insideUnitCircle;
    }
}
