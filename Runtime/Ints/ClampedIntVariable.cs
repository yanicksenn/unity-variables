using System;
using UnityEngine;
using Variables.Ints;

namespace Variables.Floats
{
    /// <summary>
    /// Clamped int variable wrapped in a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(
        menuName = VariableConstants.IntMenu + "/Create clamped int variable", 
        fileName = "ClampedIntVariable",
        order = 2)]
    public class ClampedIntVariable : IntVariable
    {
        [SerializeField] 
        private IntReference minValue = new IntReference(int.MinValue);
        public IntReference MinValue => minValue;
        
        [SerializeField] 
        private IntReference maxValue = new IntReference(int.MaxValue);
        public IntReference MaxValue => maxValue;

        protected override int Interpolate(int newValue)
        {
            return Math.Clamp(newValue, MinValue.GetValue(), MaxValue.GetValue());
        }
    }
}
