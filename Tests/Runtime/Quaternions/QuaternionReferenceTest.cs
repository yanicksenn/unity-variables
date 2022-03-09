using UnityEngine;
using Variables.Quaternions;

namespace Variables.Tests.Quaternions
{
    public class QuaternionReferenceTest : AbstractReferenceTest<Quaternion, QuaternionValueContainer, QuaternionReference>
    {
        protected override QuaternionReference CreateReference()
        {
            return new QuaternionReference();
        }

        protected override QuaternionValueContainer CreateVariable()
        {
            return ScriptableObject.CreateInstance<QuaternionValueContainer>();
        }

        protected override Quaternion CreateRandomValue()
        {
            return Random.rotation;
        }
    }
}