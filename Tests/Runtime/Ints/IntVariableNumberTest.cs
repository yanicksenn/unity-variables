using UnityEngine;
using Variables.Ints;

namespace Variables.Tests.Ints
{
    public class IntVariableNumberTest : AbstractNumberContainerTest<int, IntVariable>
    {
        protected override int Inv(int value) => -value;
        protected override int Inc(int value) => value + 1;
        protected override int Dec(int value) => value - 1;
        protected override int Add(int value1, int value2) => value1 + value2;
        protected override int Sub(int value1, int value2) => value1 - value2;
        protected override int Mul(int value1, int value2) => value1 * value2;
        protected override int Div(int value1, int value2) => value1 / value2;

        protected override IntVariable CreateValueContainer() => ScriptableObject.CreateInstance<IntVariable>();
        protected override int CreateRandomValue() => Random.Range(1, 1000);
    }
}