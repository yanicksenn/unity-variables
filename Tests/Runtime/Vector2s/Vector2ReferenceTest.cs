using UnityEngine;
using Variables.Floats;
using Variables.Vector2s;

namespace Variables.Tests.Vector2s
{
    public class Vector2ReferenceTest : AbstractReferenceTest<Vector2, Vector2Reference, Vector2Variable, Vector2Event>
    {
        protected override Vector2Reference CreateValueContainer() => new Vector2Reference();
        protected override Vector2 CreateRandomValue() => Random.insideUnitCircle;
    }
}