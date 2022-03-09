using UnityEngine;
using Variables.Vector2s;

namespace Variables.Tests.Quaternions
{
    public class Vector2ReferenceTest : AbstractValueContainerTest<Vector2, Vector2Reference>
    {
        protected override Vector2Reference CreateValueContainer() => new Vector2Reference();
        protected override Vector2 CreateRandomValue() => Random.insideUnitCircle;
    }
}