using System;

namespace Variables.Ints
{
    [Serializable]
    public class IntReference : AbstractReference<int, IntVariable>
    {
        public IntReference(int defaultConstantValue = 0) : base(defaultConstantValue)
        {
        }
    }
}