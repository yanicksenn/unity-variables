using System;

namespace Variables.Strings
{
    [Serializable]
    public class StringReference : AbstractReference<string, StringValueContainer>
    {
        public StringReference(string defaultConstantValue = "") : base(defaultConstantValue)
        {
        }
    }
}