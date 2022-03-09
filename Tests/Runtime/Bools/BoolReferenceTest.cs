using UnityEngine;
using Variables.Bools;

namespace Variables.Tests.Bools
{
    public class BoolReferenceTest : AbstractValueContainerTest<bool, BoolReference>
    {
        protected override BoolReference CreateValueContainer() => new BoolReference();
        protected override bool CreateRandomValue() => Random.Range(0, 1) == 0;
    }
}