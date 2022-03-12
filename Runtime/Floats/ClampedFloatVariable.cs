using System;
using UnityEngine;

namespace Variables.Floats
{
    /// <summary>
    /// Clamped float variable wrapped in a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(
        menuName = VariableConstants.FloatMenu + "/Create clamped float variable", 
        fileName = "ClampedFloatVariable",
        order = 2)]
    public class ClampedFloatVariable : FloatVariable
    {
        [SerializeField] 
        private FloatReference minValue = new FloatReference(float.MinValue);
        
        /// <summary>
        /// Minimal value that can be assigned.
        /// </summary>
        public FloatReference MinValue => minValue;
        
        [SerializeField] 
        private FloatReference maxValue = new FloatReference(float.MaxValue);
        
        /// <summary>
        /// Maximal value that can be assigned.
        /// </summary>
        public FloatReference MaxValue => maxValue;

        protected override float Interpolate(float newValue)
        {
            return Math.Clamp(newValue, MinValue.GetValue(), MaxValue.GetValue());
        }
    }
}
