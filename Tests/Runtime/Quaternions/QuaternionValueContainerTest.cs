using Variables.Quaternions;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Quaternions
{
    [UsedImplicitly]
    public class QuaternionValueContainerTest : AbstractValueContainerTest<Quaternion>
    {
        protected override IValueContainer<Quaternion> CreateVariable() => ScriptableObject.CreateInstance<QuaternionValueContainer>();

        protected override Quaternion CreateRandomValue() => Random.rotation;
    }
}
