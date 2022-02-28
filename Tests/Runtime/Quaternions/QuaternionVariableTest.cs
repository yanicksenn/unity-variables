using Variables.Quaternions;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Quaternions
{
    [UsedImplicitly]
    public class QuaternionVariableTest : AbstractVariableTest<Quaternion>
    {
        protected override AbstractVariable<Quaternion> CreateVariable() => ScriptableObject.CreateInstance<QuaternionVariable>();

        protected override Quaternion GetValue() => new Quaternion(1f, 2f, 3f, 4f);
    }
}
