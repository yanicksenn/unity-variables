using Variables.Floats;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Floats
{
    [UsedImplicitly]
    public class FloatVariableTest : AbstractVariableTest<float>
    {
        protected override IValueContainer<float> CreateVariable() => ScriptableObject.CreateInstance<FloatValueContainer>();

        protected override float CreateRandomValue() => Random.Range(-1000f, 1000f);
    }
}
