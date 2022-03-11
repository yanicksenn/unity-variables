using System;

namespace Variables.Bools
{
    /// <summary>
    /// Bool reference allowing to switch between constant and variable.
    /// </summary>
    [Serializable]
    public class BoolReference : AbstractReference<bool, BoolVariable, BoolEvent>, IInvertible
    {
        public BoolReference(bool defaultConstantValue = false) : base(defaultConstantValue)
        {
        }
        
        public void Inv() => SetValue(!GetValue());
    }
}