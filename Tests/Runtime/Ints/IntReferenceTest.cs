using UnityEngine;
using Variables.Floats;
using Variables.Ints;

namespace Variables.Tests.Ints
{
    public class IntReferenceTest : AbstractReferenceTest<int, IntReference, IntVariable, IntEvent>
    {
        protected override IntReference CreateValueContainer() => new IntReference();

        protected override int CreateRandomValue() => Random.Range(1, 1000);
    }
}