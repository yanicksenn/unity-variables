using UnityEngine;
using Variables.Quaternions;

namespace Variables.Tests.Quaternions
{
    public class QuaternionReferenceTest : AbstractValueContainerTest<Quaternion, QuaternionReference>
    {
        protected override QuaternionReference CreateValueContainer() => new QuaternionReference();
        protected override Quaternion CreateRandomValue() => Random.rotation;
    }
}