using UnityEngine;
using Variables.Floats;
using Variables.Ints;
using Random = UnityEngine.Random;

namespace Variables.Tests.Bools
{
    public class IntReferenceTest : AbstractNumberReferenceTest<int, IntValueContainer, IntReference>
    {
        protected override int Inv(int value) => -value;
        protected override int Inc(int value) => value + 1;
        protected override int Dec(int value) => value - 1;
        protected override int Add(int value1, int value2) => value1 + value2;
        protected override int Sub(int value1, int value2) => value1 - value2;
        protected override int Mul(int value1, int value2) => value1 * value2;
        protected override int Div(int value1, int value2) => value1 / value2;
        
        protected override IntReference CreateReference()
        {
            return new IntReference();
        }

        protected override IntValueContainer CreateVariable()
        {
            return ScriptableObject.CreateInstance<IntValueContainer>();
        }

        protected override int CreateRandomValue()
        {
            return Random.Range(1, 1000);
        }
    }
}