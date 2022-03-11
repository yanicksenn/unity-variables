using UnityEngine;
using Variables.Floats;

namespace Variables.Tests.Floats
{
    public class FloatReferenceTest : AbstractReferenceTest<float, FloatReference, FloatVariable, FloatEvent>
    {
        protected override FloatReference CreateValueContainer() => new FloatReference();
        protected override float CreateRandomValue() => Random.Range(1f, 1000f);
    }
}