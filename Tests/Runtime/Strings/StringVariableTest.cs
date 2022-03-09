using Variables.Strings;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Strings
{
    [UsedImplicitly]
    public class StringVariableTest : AbstractVariableTest<string>
    {
        protected override IVariable<string> CreateVariable() => ScriptableObject.CreateInstance<StringVariable>();

        protected override string CreateRandomValue() => "Not so random string";
    }
}
