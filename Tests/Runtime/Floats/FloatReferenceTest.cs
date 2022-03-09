using UnityEngine;
using Variables.Floats;

namespace Variables.Tests.Bools
{
    public class FloatReferenceTest : AbstractReferenceTest<float, FloatReference, FloatVariable>
    {
        /*protected override float Inv(float value) => -value;
        protected override float Inc(float value) => value + 1;
        protected override float Dec(float value) => value - 1;
        protected override float Add(float value1, float value2) => value1 + value2;
        protected override float Sub(float value1, float value2) => value1 - value2;
        protected override float Mul(float value1, float value2) => value1 * value2;
        protected override float Div(float value1, float value2) => value1 / value2;*/

        protected override FloatReference CreateValueContainer() => new FloatReference();
        protected override float CreateRandomValue() => Random.Range(1f, 1000f);
    }
}