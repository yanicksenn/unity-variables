using UnityEngine;
using Variables.Vector3s;

namespace Variables.Tests.Quaternions
{
    public class Vector3ReferenceTest : AbstractReferenceTest<Vector3, Vector3Variable, Vector3Reference>
    {
        protected override Vector3Reference CreateReference()
        {
            return new Vector3Reference();
        }

        protected override Vector3Variable CreateVariable()
        {
            return ScriptableObject.CreateInstance<Vector3Variable>();
        }

        protected override Vector3 CreateRandomValue()
        {
            return Random.insideUnitSphere;
        }
    }
}