using UnityEngine;
using Variables.Vector2s;

namespace Variables.Tests.Quaternions
{
    public class Vector2ReferenceTest : AbstractReferenceTest<Vector2, Vector2Reference, Vector2Variable>
    {
        protected override Vector2Reference CreateValueContainer() => new Vector2Reference();
        protected override Vector2 CreateRandomValue() => Random.insideUnitCircle;
    }
}