using Variables.Bools;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Bools
{
    [UsedImplicitly]
    public class BoolVariableTest : AbstractVariableTest<bool>
    {
        protected override AbstractVariable<bool> CreateVariable() => ScriptableObject.CreateInstance<BoolVariable>();

        protected override bool GetValue() => true;
    }
}
