using UnityEngine;
using Variables.Quaternions;

namespace Variables.Tests.Quaternions
{
    public class QuaternionReferenceTest : AbstractReferenceTest<Quaternion, QuaternionVariable, QuaternionReference>
    {
        protected override QuaternionReference CreateReference()
        {
            return new QuaternionReference();
        }

        protected override QuaternionVariable CreateVariable()
        {
            return ScriptableObject.CreateInstance<QuaternionVariable>();
        }

        protected override Quaternion CreateRandomValue()
        {
            return Random.rotation;
        }
    }
}