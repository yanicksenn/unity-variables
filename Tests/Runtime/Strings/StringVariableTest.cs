using Variables.Strings;
using UnityEngine;

namespace Variables.Tests.Strings
{
    public class StringVariableTest : AbstractValueContainerTest<string, StringVariable>
    {
        protected override StringVariable CreateValueContainer() => ScriptableObject.CreateInstance<StringVariable>();
        protected override string CreateRandomValue() => "Not so random string";
    }
}
