using UnityEngine;
using Variables.Bools;

namespace Variables.Tests.Bools
{
    public class BoolReferenceTest : AbstractReferenceTest<bool, BoolReference, BoolVariable>
    {
        protected override BoolReference CreateValueContainer() => new BoolReference();
        protected override bool CreateRandomValue() => Random.Range(0, 1) == 0;
    }
}