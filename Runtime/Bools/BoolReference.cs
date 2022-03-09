using System;
using Variables.unity_variables.Runtime;

namespace Variables.Bools
{
    /// <summary>
    /// Bool reference allowing to switch between constant and variable.
    /// </summary>
    [Serializable]
    public class BoolReference : AbstractReference<bool, BoolValueContainer>, IBoolOperations
    {
        public BoolReference(bool defaultConstantValue = false) : base(defaultConstantValue)
        {
        }
        
        public void Inv() => SetValue(!GetValue());
        public void True() => SetValue(true);
        public void False() => SetValue(false);
    }
}