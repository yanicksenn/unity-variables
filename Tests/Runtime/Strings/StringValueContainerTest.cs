using Variables.Strings;
using JetBrains.Annotations;
using UnityEngine;

namespace Variables.Tests.Strings
{
    [UsedImplicitly]
    public class StringValueContainerTest : AbstractValueContainerTest<string>
    {
        protected override IValueContainer<string> CreateVariable() => ScriptableObject.CreateInstance<StringValueContainer>();

        protected override string CreateRandomValue() => "Not so random string";
    }
}
