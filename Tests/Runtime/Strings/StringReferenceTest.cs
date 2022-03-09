using Variables.Strings;

namespace Variables.Tests.Quaternions
{
    public class StringReferenceTest : AbstractReferenceTest<string, StringReference, StringVariable>
    {
        protected override StringReference CreateValueContainer() => new StringReference();
        protected override string CreateRandomValue() => "Not so random string";
    }
}