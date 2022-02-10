using System;

namespace CraipaiGames.Variables.Strings
{
    [Serializable]
    public class StringReference : AbstractReference<string, StringVariable>
    {
        public StringReference(string defaultConstantValue = "") : base(defaultConstantValue)
        {
        }
    }
}