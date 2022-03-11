using System;
using UnityEngine;

namespace Variables.Floats
{
    [CreateAssetMenu(
        menuName = VariableConstants.FloatMenu + "/Create clamped float variable", 
        fileName = "ClampedFloatVariable",
        order = 2)]
    public class ClampedFloatVariable : FloatVariable
    {
        [SerializeField] 
        private FloatReference minValue = new FloatReference(float.MinValue);
        public FloatReference MinValue => minValue;
        
        [SerializeField] 
        private FloatReference maxValue = new FloatReference(float.MaxValue);
        public FloatReference MaxValue => maxValue;

        protected override float Interpolate(float newValue)
        {
            return Math.Clamp(newValue, MinValue.GetValue(), MaxValue.GetValue());
        }
    }
}
