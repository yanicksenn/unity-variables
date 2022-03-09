using Variables.Quaternions;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Quaternions
{
    [UsedImplicitly]
    public class QuaternionVariableTest : AbstractValueContainerTest<Quaternion, QuaternionVariable>
    {
        protected override QuaternionVariable CreateValueContainer() => ScriptableObject.CreateInstance<QuaternionVariable>();
        protected override Quaternion CreateRandomValue() => Random.rotation;
    }
}
