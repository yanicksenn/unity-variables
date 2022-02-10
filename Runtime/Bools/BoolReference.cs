using System;

namespace CraipaiGames.Variables.Bools
{
    [Serializable]
    public class BoolReference : AbstractReference<bool, BoolVariable>
    {
        public BoolReference(bool defaultConstantValue = false) : base(defaultConstantValue)
        {
        }
    }
}