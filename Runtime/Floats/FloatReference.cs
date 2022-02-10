using System;

namespace CraipaiGames.Variables.Floats
{
    [Serializable]
    public class FloatReference : AbstractReference<float, FloatVariable>
    {
        public FloatReference(float defaultConstantValue = 0.0f) : base(defaultConstantValue)
        {
        }
    }
}