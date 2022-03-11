using UnityEngine;
using Variables.Floats;
using Variables.Vector3s;

namespace Variables.Tests.Vector3s
{
    public class Vector3ReferenceTest : AbstractReferenceTest<Vector3, Vector3Reference, Vector3Variable, Vector3Event>
    {
        protected override Vector3Reference CreateValueContainer() => new Vector3Reference();
        protected override Vector3 CreateRandomValue() => Random.insideUnitSphere;
    }
}