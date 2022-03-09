using UnityEngine;
using Variables.Quaternions;

namespace Variables.Tests.Quaternions
{
    public class QuaternionReferenceTest : AbstractReferenceTest<Quaternion, QuaternionReference, QuaternionVariable>
    {
        protected override QuaternionReference CreateValueContainer() => new QuaternionReference();
        protected override Quaternion CreateRandomValue() => Random.rotation;
    }
}