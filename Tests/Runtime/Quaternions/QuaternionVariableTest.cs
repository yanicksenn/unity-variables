using Variables.Quaternions;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Quaternions
{
    [UsedImplicitly]
    public class QuaternionVariableTest : AbstractVariableTest<Quaternion>
    {
        protected override IVariable<Quaternion> CreateVariable() => ScriptableObject.CreateInstance<QuaternionVariable>();

        protected override Quaternion CreateRandomValue() => Random.rotation;
    }
}
