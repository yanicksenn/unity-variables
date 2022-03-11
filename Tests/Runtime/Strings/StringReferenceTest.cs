using Variables.Floats;
using Variables.Strings;

namespace Variables.Tests.Strings
{
    public class StringReferenceTest : AbstractReferenceTest<string, StringReference, StringVariable, StringEvent>
    {
        protected override StringReference CreateValueContainer() => new StringReference();
        protected override string CreateRandomValue() => "Not so random string";
    }
}