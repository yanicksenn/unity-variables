using Variables.Bools;
using UnityEngine;

namespace Variables.Tests.Bools
{
    public class BoolValueContainerTest : AbstractValueContainerTest<bool>
    {
        protected override IValueContainer<bool> CreateVariable() => ScriptableObject.CreateInstance<BoolValueContainer>();

        protected override bool CreateRandomValue() => Random.Range(0, 1) == 0;
    }
}
