using System;
using Variables.Floats;

namespace Variables.Strings
{
    [Serializable]
    public class StringReference : AbstractReference<string, StringVariable, StringEvent>
    {
        public StringReference(string defaultConstantValue = "") : base(defaultConstantValue)
        {
        }
    }
}