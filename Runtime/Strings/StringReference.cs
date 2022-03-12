using System;
using Variables.Floats;

namespace Variables.Strings
{
    /// <summary>
    /// String reference allowing to switch between constant and variable.
    /// </summary>
    [Serializable]
    public class StringReference : AbstractReference<string, StringVariable, StringEvent>
    {
        public StringReference(string defaultConstantValue = "") : base(defaultConstantValue)
        {
        }
    }
}