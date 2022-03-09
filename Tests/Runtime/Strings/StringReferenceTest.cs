using Variables.Strings;

namespace Variables.Tests.Quaternions
{
    public class StringReferenceTest : AbstractValueContainerTest<string, StringReference>
    {
        protected override StringReference CreateValueContainer() => new StringReference();
        protected override string CreateRandomValue() => "Not so random string";
    }
}