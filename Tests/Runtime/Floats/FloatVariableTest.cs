using Variables.Floats;
using UnityEngine;

namespace Variables.Tests.Floats
{
    public class FloatVariableTest : AbstractValueContainerTest<float, FloatVariable>
    {
        protected override FloatVariable CreateValueContainer() => ScriptableObject.CreateInstance<FloatVariable>();
        protected override float CreateRandomValue() => Random.Range(-1000f, 1000f);
    }
}
