using UnityEngine;
using Variables.Floats;
using Variables.Quaternions;

namespace Variables.Tests.Quaternions
{
    public class QuaternionReferenceTest : AbstractReferenceTest<Quaternion, QuaternionReference, QuaternionVariable, QuaternionEvent>
    {
        protected override QuaternionReference CreateValueContainer() => new QuaternionReference();
        protected override Quaternion CreateRandomValue() => Random.rotation;
    }
}