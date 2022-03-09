using UnityEngine;
using Variables.Vector3s;

namespace Variables.Tests.Quaternions
{
    public class Vector3ReferenceTest : AbstractValueContainerTest<Vector3, Vector3Reference>
    {
        protected override Vector3Reference CreateValueContainer() => new Vector3Reference();
        protected override Vector3 CreateRandomValue() => Random.insideUnitSphere;
    }
}