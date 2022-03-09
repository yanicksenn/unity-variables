using UnityEngine;
using Variables.Floats;
using Random = UnityEngine.Random;

namespace Variables.Tests.Bools
{
    public class FloatReferenceTest : AbstractNumberReferenceTest<float, FloatVariable, FloatReference>
    {
        protected override float Inv(float value) => -value;
        protected override float Inc(float value) => value + 1;
        protected override float Dec(float value) => value - 1;
        protected override float Add(float value1, float value2) => value1 + value2;
        protected override float Sub(float value1, float value2) => value1 - value2;
        protected override float Mul(float value1, float value2) => value1 * value2;
        protected override float Div(float value1, float value2) => value1 / value2;
        
        protected override FloatReference CreateReference()
        {
            return new FloatReference();
        }

        protected override FloatVariable CreateVariable()
        {
            return ScriptableObject.CreateInstance<FloatVariable>();
        }

        protected override float CreateRandomValue()
        {
            return Random.Range(1f, 1000f);
        }
    }
}